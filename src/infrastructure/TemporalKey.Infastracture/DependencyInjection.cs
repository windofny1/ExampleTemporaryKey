using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TemporalKey.Infastracture.Persistence.DbContexts;

namespace TemporalKey.Infastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastracture(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddPersistence(configuration); 
            return services;
        }
        private static IServiceCollection AddPersistence(this IServiceCollection services,ConfigurationManager configuration)
        {
          
            services.AddDbContext<TemporalKeyDbContext>(options => {
                options.EnableDetailedErrors().EnableSensitiveDataLogging();
                options.UseSqlServer(configuration.GetConnectionString("DbConnection")!,
                        x => x.MigrationsAssembly("TemporalKey.Infastracture")
                    );
            });
        
            return services;
        }        
    }
}
