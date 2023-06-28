using Domain;
using MediatR;

namespace Application.Features.Books.Commands.AddBook
{
    public class AddBookCommand : IRequest<int>
    {
        public Book Book { get; set; }
    }
}
