using Domain;
using MediatR;

namespace Application.Features.Reserves.Commands.DoReserve
{
    public class DoReserveCommand : IRequest<int>
    {
        public Reserve Reserve { get; set; }
    }
}
