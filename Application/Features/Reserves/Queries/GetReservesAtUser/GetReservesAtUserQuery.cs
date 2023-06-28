using Domain;
using MediatR;

namespace Application.Features.Reserves.Queries.GetReservesAtUser
{
    public class GetReservesAtUserQuery : IRequest<List<Reserve>>
    {
        public User User { get; set; }
    }
}
