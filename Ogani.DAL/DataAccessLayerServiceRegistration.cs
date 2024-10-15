using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ogani.DAL.DataContext;

namespace Ogani.DAL
{
    public static class DataAccessLayerServiceRegistration
    {
        
        public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration )
        {
            
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("default"),
            builder =>
            {
                builder.MigrationsAssembly("Ogani.DAL");
            }));

            return services;
        }
    }
}
