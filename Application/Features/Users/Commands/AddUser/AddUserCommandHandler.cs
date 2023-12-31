﻿using Application.Interfaces;
using MediatR;

namespace Application.Features.Users.Commands.AddUser
{
    internal class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly IAppDbContext context;

        public AddUserCommandHandler(IAppDbContext dbContext)
        {
            this.context = dbContext;
        }

        async public Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.User;
            await context.Users.AddAsync(user, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
