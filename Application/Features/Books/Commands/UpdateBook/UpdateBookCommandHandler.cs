using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Books.Commands.UpdateBook
{
    internal class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IAppDbContext context;
        public UpdateBookCommandHandler(IAppDbContext dbContext)
        {
            this.context = dbContext;
        }
        async public Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await context.Books.FirstAsync(c => c.Id == request.Book.Id, cancellationToken);
            book = request.Book;
            await context.SaveChangesAsync(cancellationToken);
            return book.Id;
        }
    }
}
