using Application.Features.Reserves.Commands.UpdateReserve;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Persistence.Planner.Jobs
{
    public class DateChecker : IJob
    {
        private readonly IServiceScopeFactory ServiceScopeFactory;

        public DateChecker(IServiceScopeFactory ServiceScopeFactory)
        {
            this.ServiceScopeFactory = ServiceScopeFactory;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var Mediator = scope.ServiceProvider.GetService<IMediator>();
                await Mediator.Send(new UpdateReserveCommand());
            }
        }
    }
}
