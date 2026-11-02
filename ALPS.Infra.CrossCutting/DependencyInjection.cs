using ALPS.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ALPS.Infra.CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
             this IServiceCollection services,
             IConfiguration configuration
             )
        {
            var connectionString = configuration.GetConnectionString("ALPSConnection");

            services.AddDbContext<ALPSDbContext>(options =>
                options.UseNpgsql(connectionString,
                b => b.MigrationsAssembly(typeof(ALPSDbContext).Assembly.FullName)
                ));
            return services;
        }
    }
}
