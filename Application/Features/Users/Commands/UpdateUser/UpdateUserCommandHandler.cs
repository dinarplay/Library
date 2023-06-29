using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Commands.UpdateUser
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IAppDbContext context;

        public UpdateUserCommandHandler(IAppDbContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstAsync(c => c.Id == request.User.Id, cancellationToken);
            user.Name = request.User.Name;
            user.Password = User.SetPassword(request.User.Password);
            user.Email = request.User.Email;
            user.RoleId = request.User.RoleId;
            await context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
