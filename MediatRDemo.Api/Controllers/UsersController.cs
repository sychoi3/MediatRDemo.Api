using MediatR;
using MediatRDemo.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UsersController> _logger;
        private readonly IMediator mediator;
        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var query = new GetUserByIdQuery(Guid.NewGuid());
            var result = mediator.Send(query);

            return Ok(result);
        }
    }
}