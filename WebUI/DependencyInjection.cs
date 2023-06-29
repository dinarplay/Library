using Application.Interfaces;
using WebUI.Interfaces;
using WebUI.Services;

namespace WebUI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddTransient<IUserManager, UserManagerService>();
            services.AddTransient<IUserDisplay, UserDisplayService>();

            services.AddTransient<IBookManager, BookManagerService>();
            services.AddTransient<IBookDisplay, BookDisplayService>();

            services.AddTransient<IReserveManager, ReserveManagerService>();
            services.AddTransient<IReserveDisplay, ReserveDisplayService>();

            services.AddTransient<IDataManager, DataManagerService>();

            return services;
        }
    }
}
