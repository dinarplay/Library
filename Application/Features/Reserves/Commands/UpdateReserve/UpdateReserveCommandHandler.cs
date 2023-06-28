using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Reserves.Commands.UpdateReserve
{
    public class UpdateReserveCommandHandler : IRequestHandler<UpdateReserveCommand, int>
    {
        private readonly IAppDbContext context;
        public UpdateReserveCommandHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }
        async public Task<int> Handle(UpdateReserveCommand request, CancellationToken cancellationToken)
        {
            var reserves = await context.Reserves.ToListAsync();
            foreach (var item in reserves)
            {
                if (item.Canceling < DateTime.Now)
                {
                    context.Reserves.Remove(item);
                    var book = await context.Books.FirstAsync(c => c.Id == item.BookId, cancellationToken);
                    book.Count++;
                }
            }
            await context.SaveChangesAsync(cancellationToken);
            return reserves.First().Id;
            //tot yt ljitk
        }
    }
}
