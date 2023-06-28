using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Books.Queries.GetAllGenres
{
    public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, List<Genre>>
    {
        private readonly IAppDbContext context;
        public GetAllGenresQueryHandler(IAppDbContext dbContext)
        {
            context = dbContext;
        }
        async public Task<List<Genre>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = await context.Genres.ToListAsync();
            return genres;
        }
    }
}
