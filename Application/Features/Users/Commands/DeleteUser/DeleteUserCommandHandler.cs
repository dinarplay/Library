using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Commands.DeleteUser
{
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IAppDbContext context;

        public DeleteUserCommandHandler(IAppDbContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstAsync(c => c.Id == request.User.Id, cancellationToken);
            if (user == null)
            {
                return default;
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
