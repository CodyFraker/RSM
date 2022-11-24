using dotenv.net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RSMModels.Context;
using System;

namespace RSMApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DotEnv.Load();
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddDbContext<RSMDbContext>(options => options.UseMySql(RSMDbContext.ConnectionString, ServerVersion.AutoDetect(RSMDbContext.ConnectionString)));
            services.AddSingleton<OpenBreweryHandler>();
        }
    }
}