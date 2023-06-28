using Domain;
using MediatR;

namespace Application.Features.Reserves.Commands.TakeReserve
{
    public class TakeReserveCommand : IRequest<int>
    {
        public Reserve Reserve { get; set; }
    }
}
