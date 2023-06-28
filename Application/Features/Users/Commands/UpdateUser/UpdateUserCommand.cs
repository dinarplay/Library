using Domain;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public User User { get; set; }
    }
}
