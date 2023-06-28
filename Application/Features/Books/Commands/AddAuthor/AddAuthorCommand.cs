using Domain;
using MediatR;

namespace Application.Features.Books.Commands.AddAuthor
{
    public class AddAuthorCommand : IRequest<int>
    {
        public Author Author { get; set; }
    }
}
