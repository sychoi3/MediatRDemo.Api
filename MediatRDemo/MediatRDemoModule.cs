using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MediatRDemo
{
    public static class MediatRDemoModule
    {
        public static void AddMediatRDemoModule(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
        }
    }
}
