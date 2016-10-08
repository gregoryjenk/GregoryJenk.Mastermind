using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);

            if (hostingEnvironment.IsDevelopment())
            {
                //Add development environment settings here.
            }

            configurationBuilder.AddEnvironmentVariables();

            _configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthentication(configureOptions => configureOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);

            serviceCollection.AddMvc()
                .AddJsonOptions(mvcJsonOptions => mvcJsonOptions.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);
        }

        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            applicationBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookies",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                ExpireTimeSpan = TimeSpan.FromDays(1),
                LoginPath = "/login"
            });

            applicationBuilder.UseGoogleAuthentication(new GoogleOptions()
            {
                ClientId = _configuration["authentication:google:clientId"],
                ClientSecret = _configuration["authentication:google:clientSecret"]
            });

            if (hostingEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
            }
            else
            {
                applicationBuilder.UseExceptionHandler("/error");
            }

            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseMvc();
        }
    }
}