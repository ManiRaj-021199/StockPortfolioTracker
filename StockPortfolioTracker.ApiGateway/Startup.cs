using System;
using Microsoft.AspNetCore;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace StockPortfolioTracker.ApiGateway
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(hostEnvironment.ContentRootPath)
                   .AddJsonFile(Path.Combine("Configuration", "configuration.json"), optional: false, reloadOnChange: true)
                   .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);

            builder.ConfigureServices(s => s.AddSingleton(builder))
                   .ConfigureAppConfiguration(ic => ic.AddJsonFile(Path.Combine("Configuration", "configuration.json")))
                   .UseStartup<Startup>();
            var host = builder.Build();
            return host;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot(Configuration);
        }

        public async void Configure(IApplicationBuilder app)
        {
            await app.UseOcelot();
        }
    }
}
