using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Books.Queries.GetBookById
{
    internal class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IAppDbContext context;

        public GetBookByIdQueryHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }

        async public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await context.Books.FirstAsync(c => c.Id == request.Id, cancellationToken);
            return book;
        }
    }
}
