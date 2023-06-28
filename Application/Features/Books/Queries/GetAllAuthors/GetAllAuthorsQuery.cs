using Domain;
using MediatR;

namespace Application.Features.Books.Queries.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<List<Author>>
    {
    }
}
