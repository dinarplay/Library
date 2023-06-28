using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Reserves.Commands.DoReserve
{
    public class DoReserveCommandHandler : IRequestHandler<DoReserveCommand, int>
    {
        private readonly IAppDbContext context;
        public DoReserveCommandHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }
        async public Task<int> Handle(DoReserveCommand request, CancellationToken cancellationToken)
        {
            var reserves = await context.Reserves.FirstOrDefaultAsync(c => c.BookId == request.Reserve.Book.Id && c.UserId == request.Reserve.User.Id && c.IsDone == false, cancellationToken);
            var book = await context.Books.FirstAsync(c => c.Id == request.Reserve.Book.Id, cancellationToken);
            if (reserves is null && book.Count > 0)
            {
                var reserve = new Reserve
                {
                    IsTaken = false,
                    IsDone = false,
                    Created = DateTime.Now,
                    Canceling = DateTime.Now.AddHours(24),
                    UserId = request.Reserve.User.Id,
                    BookId = request.Reserve.Book.Id
                };
                book.Count--;
                await context.Reserves.AddAsync(reserve, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                return reserve.Id;
            }
            return default;
        }
    }
}
