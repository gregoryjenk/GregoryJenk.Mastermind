using GregoryJenk.Mastermind.Web.Mvc.Factories.Users;
using GregoryJenk.Mastermind.Web.Mvc.Hubs.Games;
using GregoryJenk.Mastermind.Web.Mvc.Options.Authentication.Google;
using GregoryJenk.Mastermind.Web.Mvc.Options.Authentication.Jwt;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Games;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Google;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Games;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users;
using GregoryJenk.Mastermind.Web.Mvc.Services.Tokens;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddApplicationInsightsTelemetry((ApplicationInsightsServiceOptions applicationInsightsServiceOptions) =>
            {
                applicationInsightsServiceOptions.EnableHeartbeat = true;
                //applicationInsightsServiceOptions.EnableRequestTrackingTelemetryModule = true;
                //applicationInsightsServiceOptions.InstrumentationKey = _configuration["ApplicationInsights:InstrumentationKey"];
            });

            //Binding configuration option objects to sections in the configurations.
            serviceCollection.AddOptions();

            serviceCollection.Configure((GameServiceOption gameServiceOption) =>
            {
                _configuration.GetSection("services:game").Bind(gameServiceOption);
            });

            serviceCollection.Configure((GoogleAuthenticationOption googleAuthenticationOption) =>
            {
                _configuration.GetSection("Authentication:google").Bind(googleAuthenticationOption);
            });
            
            serviceCollection.Configure((GoogleServiceOption googleServiceOption) =>
            {
                _configuration.GetSection("services:google").Bind(googleServiceOption);
            });
            
            serviceCollection.Configure((JwtAuthenticationOption jwtAuthenticationOption) =>
            {
                _configuration.GetSection("Authentication:JwtBearer").Bind(jwtAuthenticationOption);
            });

            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer((JwtBearerOptions jwtBearerOptions) =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:JwtBearer:IssuerSigningKey"])),
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidAudience = _configuration["Authentication:JwtBearer:ValidAudience"],
                        ValidIssuer = "GregoryJenk.Mastermind.Web.Mvc"
                    };
                });

            serviceCollection.AddControllersWithViews((MvcOptions mvcOptions) =>
            {
                mvcOptions.RespectBrowserAcceptHeader = true;
            })
                //.AddJsonOptions((JsonOptions jsonOptions) =>
                //{
                //})
                .AddNewtonsoftJson((MvcNewtonsoftJsonOptions mvcJsonOptions) =>
                {
                    mvcJsonOptions.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    mvcJsonOptions.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    //mvcJsonOptions.SerializerSettings.DateFormatString = "U";
                    mvcJsonOptions.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                    mvcJsonOptions.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    mvcJsonOptions.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                });

            //Register implementations for Depedency Injection here.
            serviceCollection.AddSingleton<ExternalUserServiceClientFactory>();

            serviceCollection.AddTransient<IGameServiceClient, GameServiceClient>();
            serviceCollection.AddTransient<ITokenService, JwtService>();
            serviceCollection.AddTransient<IUserServiceClient, UserServiceClient>();

            //There is an issue with IHttpContextAccessor, it's not being injected automatically, so needs to be registered.
            serviceCollection.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            //TODO: serviceCollection.AddHttpContextAccessor();

            serviceCollection.AddSignalR();
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            applicationBuilder.UseAuthentication();

            if (webHostEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
            }
            else
            {
                applicationBuilder.UseExceptionHandler("/error");

                applicationBuilder.UseHsts();
            }

            applicationBuilder.UseHttpsRedirection();

            //applicationBuilder.UseDefaultFiles();

            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseRouting();

            //TODO: Check whether UseAuthentication() is still needed?
            applicationBuilder.UseAuthorization();

            applicationBuilder.UseEndpoints((IEndpointRouteBuilder endpointRouteBuilder) =>
            {
                endpointRouteBuilder.MapControllers();

                endpointRouteBuilder.MapHub<GameHub>("/game");
            });
        }
    }
}