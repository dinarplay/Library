using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IAppDbContext context;
        public GetAllUsersQueryHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }
        async public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await context.Users.ToListAsync();
            return users;
        }
    }
}
