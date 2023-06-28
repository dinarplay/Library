using Domain;
using MediatR;

namespace Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; set; }
    }
}
