using Domain;
using MediatR;

namespace Application.Features.Books.Commands.AddGenre
{
    public class AddGenreCommand : IRequest<int>
    {
        public Genre Genre { get; set; }
    }
}
