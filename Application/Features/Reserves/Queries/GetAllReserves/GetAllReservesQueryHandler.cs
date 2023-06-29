using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Reserves.Queries.GetAllReserves
{
    internal class GetAllReservesQueryHandler : IRequestHandler<GetAllReservesQuery, List<Reserve>>
    {
        private readonly IAppDbContext context;

        public GetAllReservesQueryHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }

        async public Task<List<Reserve>> Handle(GetAllReservesQuery request, CancellationToken cancellationToken)
        {
            var reserves = await context.Reserves.ToListAsync();
            return reserves;
        }
    }
}
