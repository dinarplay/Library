using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Reserves.Commands.GiveReserve
{
    public class GiveReserveCommandHandler : IRequestHandler<GiveReserveCommand, int>
    {
        private readonly IAppDbContext context;
        public GiveReserveCommandHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }
        async public Task<int> Handle(GiveReserveCommand request, CancellationToken cancellationToken)
        {
            var reserve = await context.Reserves.FirstAsync(c => c.Id == request.Reserve.Id && c.UserId == request.Reserve.User.Id, cancellationToken);
            reserve.IsTaken = true;
            await context.SaveChangesAsync(cancellationToken);
            return reserve.Id;
        }
    }
}
