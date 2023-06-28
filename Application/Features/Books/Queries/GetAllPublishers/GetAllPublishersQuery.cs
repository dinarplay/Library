using Domain;
using MediatR;

namespace Application.Features.Books.Queries.GetAllPublishers
{
    public class GetAllPublishersQuery : IRequest<List<Publisher>>
    {
    }
}
