using Domain;
using MediatR;

namespace Application.Features.Reserves.Commands.DoUnreserve
{
    public class DoUnreserveCommand : IRequest<int>
    {
        public Reserve Reserve { get; set; }
    }
}
