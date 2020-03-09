using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Brewer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Brewer.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBrewerContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BrewerConnection");

            return services.AddDbContext<BrewerContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
