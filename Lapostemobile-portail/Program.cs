using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lapostemobile_portail.Models; // Assurez-vous d'importer le namespace approprié pour votre DbContext

namespace ConsoleApp
{

    class Program
    {
        static void Main(string[] args)
        {
            // Configuration
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // Services
            var serviceProvider = new ServiceCollection()
                .AddDbContext<PortailContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PortailContext>();

                // Utilisez dbContext pour interagir avec la base de données
                // Par exemple, dbContext.Customers.FirstOrDefault() ou d'autres opérations

                // Lorsque vous avez terminé, la portée sera automatiquement nettoyée
            }
        }
    }
}

