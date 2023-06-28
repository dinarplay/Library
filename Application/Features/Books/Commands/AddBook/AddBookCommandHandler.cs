using Application.Interfaces;
using MediatR;

namespace Application.Features.Books.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, int>
    {
        private readonly IAppDbContext context;
        public AddBookCommandHandler(IAppDbContext dbContext)
        {
            this.context = dbContext;
        }
        async public Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.Book;
            await context.Books.AddAsync(book, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return book.Id;
        }
    }
}
