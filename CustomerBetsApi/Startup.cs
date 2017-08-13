using AutoMapper;
using CustomerBetsApi.Configurations;
using CustomerBetsApi.Filters;
using CustomerBetsApi.HttpHandler;
using CustomerBetsApi.ServiceProxy.CustomerBetService;
using CustomerBetsApi.ServiceProxy.CustomerService;
using CustomerBetsApi.ServiceProxy.GameService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;

namespace CustomerBetsApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddAutoMapper();
            services.AddScoped<LogFilter>();

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConfigurationManager, ConfigurationManager>();
            services.AddSingleton<IHttpHandler, HttpClientHandler>();

            //Register the Services
            services.AddScoped<ICustomerServiceProxy, CustomerServiceProxy>();
            services.AddScoped<ICustomerBetServiceProxy, CustomerBetServiceProxy>();
            services.AddScoped<IRaceServiceProxy, RaceServiceProxy>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");
            app.UseMvc();
        }
    }
}
