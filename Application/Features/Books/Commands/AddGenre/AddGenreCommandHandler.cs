using Application.Interfaces;
using MediatR;

namespace Application.Features.Books.Commands.AddGenre
{
    internal class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, int>
    {
        private readonly IAppDbContext context;

        public AddGenreCommandHandler(IAppDbContext dbContext)
        {
            this.context = dbContext;
        }

        async public Task<int> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = request.Genre;
            await context.Genres.AddAsync(genre, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return genre.Id;
        }
    }
}
