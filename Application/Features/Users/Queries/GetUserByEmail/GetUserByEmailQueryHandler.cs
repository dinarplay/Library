using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetUserByEmail
{
    internal class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly IAppDbContext context;

        public GetUserByEmailQueryHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(c => c.Email == request.Email, cancellationToken);
            return user;
        }
    }
}
