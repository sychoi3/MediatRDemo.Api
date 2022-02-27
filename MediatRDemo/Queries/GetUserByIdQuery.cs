using MediatR;
using MediatRDemo.Responses;

namespace MediatRDemo.Queries
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
        public GetUserByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
