using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;

namespace Persistence.Planner.Jobs
{
    public class DateSheduler
    {
        public static async void Start(IServiceProvider serviceProvider)
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            scheduler.JobFactory = serviceProvider.GetService<JobFactory>();
            await scheduler.Start();

            IJobDetail jobDetail = JobBuilder.Create<DateChecker>().Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "default")
                .StartNow()
                .WithSimpleSchedule(x => x
                .WithIntervalInHours(1)
                .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}
