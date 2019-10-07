using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using WebCoreApp.Data.EF;

namespace WebCoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            //var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var dbInitializer = services.GetService<DbInitializer>();
                    dbInitializer.Seed().Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database");
                }
            }
            host.Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args).UseKestrel().
        //    UseContentRoot(Directory.GetCurrentDirectory()).
        //    UseConfiguration(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
        //        AddJsonFile("hosting.json", optional: true).Build()).UseStartup<Startup>();
        public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .Build();
    }
}