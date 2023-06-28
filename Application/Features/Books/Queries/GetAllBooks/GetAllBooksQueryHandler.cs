using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly IAppDbContext context;
        public GetAllBooksQueryHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }
        async public Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await context.Books.ToListAsync();
            return books;
        }
    }
}
