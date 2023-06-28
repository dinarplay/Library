using Domain;
using MediatR;

namespace Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<int>
    {
        public User User { get; set; }
    }
}
