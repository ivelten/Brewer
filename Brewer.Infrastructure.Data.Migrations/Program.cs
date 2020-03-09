using Microsoft.Extensions.DependencyInjection;
using Brewer.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Brewer.Infrastructure.Data.Migrations
{
    class Program
    {
        static readonly IConfiguration Configuration = 
                new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

        static readonly IServiceCollection Services = 
                new ServiceCollection();

        static void ConfigureServices()
        {
            Services.AddBrewerContext(Configuration);
        }

        static void Main(string[] args)
        {
            ConfigureServices();

            var serviceProvider = Services.BuildServiceProvider();
            var context = serviceProvider.GetRequiredService<BrewerContext>();
        }
    }
}
