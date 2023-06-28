using Domain;
using MediatR;

namespace Application.Features.Reserves.Commands.GiveReserve
{
    public class GiveReserveCommand : IRequest<int>
    {
        public Reserve Reserve { get; set; }
    }
}
