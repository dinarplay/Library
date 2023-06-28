using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetAllRoles
{
    public class GetAllRolesQueryHadnler : IRequestHandler<GetAllRolesQuery, List<Role>>
    {
        private readonly IAppDbContext context;
        public GetAllRolesQueryHadnler(IAppDbContext dbContext)
        {
            context = dbContext;
        }
        async public Task<List<Role>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await context.Roles.ToListAsync();
            return roles;
        }
    }
}
