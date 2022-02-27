using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;

namespace MediatRDemo
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var sw = new Stopwatch();
            sw.Start();
            //Request
            _logger.LogInformation("=================================================================================");
            _logger.LogInformation("=================================================================================");
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            Type myType = request.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(request, null);
                _logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
            }
            try
            {
                var response = await next();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                sw.Stop();
                //Response
                _logger.LogInformation($"Handled {typeof(TResponse).Name}. Took {sw.Elapsed.TotalMilliseconds} ms.");
                _logger.LogInformation("=================================================================================");
                _logger.LogInformation("=================================================================================");
            }
        }
    }
}