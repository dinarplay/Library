using Domain;
using MediatR;

namespace Application.Features.Books.Commands.AddPublisher
{
    public class AddPublisherCommand : IRequest<int>
    {
        public Publisher Publisher { get; set; }
    }
}
