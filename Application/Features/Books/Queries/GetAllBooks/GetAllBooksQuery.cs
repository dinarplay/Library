using Domain;
using MediatR;

namespace Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<Book>>
    {
    }
}
