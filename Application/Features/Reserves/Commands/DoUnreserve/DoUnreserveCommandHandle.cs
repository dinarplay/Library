using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Reserves.Commands.DoUnreserve
{
    public class DoUnreserveCommandHandle : IRequestHandler<DoUnreserveCommand, int>
    {
        private readonly IAppDbContext context;
        public DoUnreserveCommandHandle(IAppDbContext dbContext)
        {
            context = dbContext;
        }
        async public Task<int> Handle(DoUnreserveCommand request, CancellationToken cancellationToken)
        {
            var reserve = await context.Reserves.FirstAsync(c => c.Id == request.Reserve.Id && c.UserId == request.Reserve.UserId, cancellationToken);
            var book = await context.Books.FirstAsync(c => c.Id == request.Reserve.Book.Id, cancellationToken);
            book.Count++;
            context.Reserves.Remove(reserve);
            await context.SaveChangesAsync(cancellationToken);
            return reserve.Id;
            //tot yt ljitk
        }
    }
}
