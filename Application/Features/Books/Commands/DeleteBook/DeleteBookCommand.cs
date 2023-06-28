using MediatR;

namespace Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
