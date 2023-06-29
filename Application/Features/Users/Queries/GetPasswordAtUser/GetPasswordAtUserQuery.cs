using Domain;
using MediatR;

namespace Application.Features.Users.Queries.GetPasswordAtUser
{
    public class GetPasswordAtUserQuery : IRequest<string>
    {
        public User User { get; set; }
    }
}
