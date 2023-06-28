using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
    {
        private readonly IAppDbContext context;
        public DeleteBookCommandHandler(IAppDbContext dbContext)
        {
            this.context = dbContext;
        }
        public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await context.Books.FirstAsync(c => c.Id == request.Id, cancellationToken);
            context.Books.Remove(book);
            await context.SaveChangesAsync(cancellationToken);
            return book.Id;
        }
    }
}
