using MediatR;
using MediatRDemo.Models;
using MediatRDemo.Queries;
using MediatRDemo.Responses;
using Microsoft.Extensions.Logging;

namespace MediatRDemo.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly ILogger<GetUserByIdHandler> _logger;
        public GetUserByIdHandler(ILogger<GetUserByIdHandler> logger)
        {
            _logger = logger;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            // todo: logic to get user from db/api/etc.
            var user = new User();

            // todo: logic to map to Response.
            var response = new UserResponse
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth
            };
            _logger.LogInformation("GETTING USER BY ID.");

            return response;
        }
    }
}
