using Domain;
using MediatR;

namespace Application.Features.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }
    }
}
