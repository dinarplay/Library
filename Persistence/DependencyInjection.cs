using Application.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Auth;
using Persistence.Planner.Jobs;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString, c => c.MigrationsAssembly("WebUI"));
                //options.UseSqlServer(connectionString, c => c.MigrationsAssembly("WebUI"));
            });

            services.AddScoped<IAuthProvider, AuthProviderService>();
            services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<IAuthProvider>() as AuthProviderService); //sp.GetRequiredService<IAuthProvider>() загружает службу, реализующую интерфейс IAuthProvider, из контейнера служб, а затем as AuthProviderService проверяет, что загруженная служба является экземпляром AuthProviderService.
            services.AddAuthorizationCore();

            services.AddTransient<JobFactory>();
            services.AddScoped<DateChecker>();
            services.AddScoped<DateSheduler>();
            return services;
        }
    }
}
