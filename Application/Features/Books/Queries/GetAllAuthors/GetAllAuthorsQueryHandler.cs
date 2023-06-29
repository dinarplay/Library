using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Books.Queries.GetAllAuthors
{
    internal class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly IAppDbContext context;

        public GetAllAuthorsQueryHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }

        async public Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await context.Authors.ToListAsync();
            return authors;
        }
    }
}
