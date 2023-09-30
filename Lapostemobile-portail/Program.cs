using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lapostemobile_portail.Models;  
namespace ConsoleApp
{

    class Program
    {
        static void Main(string[] args)
        {
             IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

             var serviceProvider = new ServiceCollection()
                .AddDbContext<PortailContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PortailContext>();
 
            }
        }
    }
}

