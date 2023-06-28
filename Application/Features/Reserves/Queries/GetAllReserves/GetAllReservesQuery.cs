using Domain;
using MediatR;

namespace Application.Features.Reserves.Queries.GetAllReserves
{
    public class GetAllReservesQuery : IRequest<List<Reserve>>
    {
    }
}
