using Domain;
using MediatR;

namespace Application.Features.Books.Queries.GetAllGenres
{
    public class GetAllGenresQuery : IRequest<List<Genre>>
    {
    }
}
