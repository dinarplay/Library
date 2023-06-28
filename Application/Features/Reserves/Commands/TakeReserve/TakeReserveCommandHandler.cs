using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Reserves.Commands.TakeReserve
{
    public class TakeReserveCommandHandler : IRequestHandler<TakeReserveCommand, int>
    {
        private readonly IAppDbContext context;
        public TakeReserveCommandHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }
        async public Task<int> Handle(TakeReserveCommand request, CancellationToken cancellationToken)
        {
            var reserve = await context.Reserves.FirstAsync(c => c.Id == request.Reserve.Id && c.UserId == request.Reserve.User.Id, cancellationToken);
            if (reserve.IsTaken)
            {
                var book = await context.Books.FirstAsync(c => c.Id == request.Reserve.Book.Id, cancellationToken);
                book.Count++;
                reserve.IsDone = true;
                await context.SaveChangesAsync(cancellationToken);
                return reserve.Id;
            }
            return default;
        }
    }
}
