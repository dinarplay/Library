using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Reserves.Queries.GetReservesAtUser
{
    public class GetReservesAtUserQueryHandler : IRequestHandler<GetReservesAtUserQuery, List<Reserve>>
    {
        private readonly IAppDbContext context;
        public GetReservesAtUserQueryHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }
        async public Task<List<Reserve>> Handle(GetReservesAtUserQuery request, CancellationToken cancellationToken)
        {
            var reserves = await context.Reserves.Where(c => c.UserId == request.User.Id && c.IsTaken == false).ToListAsync();
            return reserves;
        }
    }
}
