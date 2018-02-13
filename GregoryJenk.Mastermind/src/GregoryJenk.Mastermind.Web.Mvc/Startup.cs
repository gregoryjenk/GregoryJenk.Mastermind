using GregoryJenk.Mastermind.Web.Mvc.Factories.Users;
using GregoryJenk.Mastermind.Web.Mvc.Options.Authentication.Google;
using GregoryJenk.Mastermind.Web.Mvc.Options.Authentication.Jwt;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Games;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Google;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Games;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users;
using GregoryJenk.Mastermind.Web.Mvc.Services.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Text;

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
                configurationBuilder.AddUserSecrets<Startup>();
            }

            configurationBuilder.AddEnvironmentVariables();

            _configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            //Binding configuration option objects to sections in the configurations.
            serviceCollection.AddOptions();

            serviceCollection.Configure<GameServiceOption>(options => _configuration.GetSection("services:game").Bind(options));
            serviceCollection.Configure<GoogleAuthenticationOption>(options => _configuration.GetSection("authentication:google").Bind(options));
            serviceCollection.Configure<GoogleServiceOption>(options => _configuration.GetSection("services:google").Bind(options));
            serviceCollection.Configure<JwtAuthenticationOption>(options => _configuration.GetSection("authentication:jwt").Bind(options));

            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(configureOptions =>
                {
                    configureOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["authentication:jwt:issuerSigningKey"])),
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidAudience = _configuration["authentication:jwt:validAudience"],
                        ValidIssuer = "GregoryJenk.Mastermind.Web.Mvc"
                    };
                });

            serviceCollection.AddMvc()
                .AddJsonOptions(mvcJsonOptions => {
                    mvcJsonOptions.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    mvcJsonOptions.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    //mvcJsonOptions.SerializerSettings.DateFormatString = "U";
                    mvcJsonOptions.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                    mvcJsonOptions.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    mvcJsonOptions.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                });

            serviceCollection.AddApplicationInsightsTelemetry(_configuration["applicationInsights:instrumentationKey"]);

            //Register implementations for Depedency Injection here.
            serviceCollection.AddSingleton<ExternalUserServiceClientFactory>();
            serviceCollection.AddTransient<IGameServiceClient, GameServiceClient>();
            serviceCollection.AddTransient<ITokenService, JwtService>();
            serviceCollection.AddTransient<IUserServiceClient, UserServiceClient>();

            //There is an issue with IHttpContextAccessor, it's not being injected automatically, so needs to be registered.
            serviceCollection.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            applicationBuilder.UseAuthentication();

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