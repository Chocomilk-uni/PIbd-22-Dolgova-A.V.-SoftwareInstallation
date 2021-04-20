using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SoftwareInstallationWarehouseApp
{
    public class Program
    {
        public static bool Authorized;

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}