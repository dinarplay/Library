using Domain;
using MediatR;

namespace Application.Features.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<int>
    {
        public User User { get; set; }
    }
}
