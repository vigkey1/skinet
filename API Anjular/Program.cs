using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Anjular
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var Services = scope.ServiceProvider;
                var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = Services.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context, LoggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = LoggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "Error accored during migration");
                }
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
