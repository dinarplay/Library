using Domain;
using MediatR;

namespace Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<int>
    {
        public Book Book { get; set; }
    }
}
