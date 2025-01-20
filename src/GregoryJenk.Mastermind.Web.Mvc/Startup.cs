using AutoMapper;
using GregoryJenk.Mastermind.Bridge.Google.Bridges;
using GregoryJenk.Mastermind.Bridge.Google.Profiles.Users;
using GregoryJenk.Mastermind.Service.Proxies;
using GregoryJenk.Mastermind.Service.Proxies.Games;
using GregoryJenk.Mastermind.Service.Proxies.Users;
using GregoryJenk.Mastermind.Service.Services.Games;
using GregoryJenk.Mastermind.Service.Services.Users;
using GregoryJenk.Mastermind.Service.Strategies.Authentication;
using GregoryJenk.Mastermind.Web.Mvc.Factories.Authentication;
using GregoryJenk.Mastermind.Web.Mvc.Factories.Users;
using GregoryJenk.Mastermind.Web.Mvc.Handlers.Authentication;
using GregoryJenk.Mastermind.Web.Mvc.Hubs.Games;
using GregoryJenk.Mastermind.Web.Mvc.Snippets.Information;
using GregoryJenk.Mastermind.Web.Mvc.Strategies.Authentication;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication;
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
using System;
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

            serviceCollection.Configure((AuthenticationAuthorityGoogleStrategyOption authenticationAuthorityGoogleStrategyOption) =>
            {
                _configuration.GetSection("Authentication:Google")
                    .Bind(authenticationAuthorityGoogleStrategyOption);
            });
            
            serviceCollection.Configure((AuthenticationTokenJwtBearerStrategyOption authenticationTokenJwtBearerStrategyOption) =>
            {
                _configuration.GetSection("Authentication:JwtBearer")
                    .Bind(authenticationTokenJwtBearerStrategyOption);
            });

            serviceCollection.Configure((BridgeOption bridgeOption) =>
            {
                _configuration.GetSection("Bridge:Google:Bridges")
                    .Bind(bridgeOption);
            });
            
            serviceCollection.Configure((ProxyOption proxyOption) =>
            {
                _configuration.GetSection("Service:Proxies")
                    .Bind(proxyOption);
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
            });
                //.AddJsonOptions((JsonOptions jsonOptions) =>
                //{
                //})
                //.AddNewtonsoftJson((MvcNewtonsoftJsonOptions mvcJsonOptions) =>
                //{
                //    mvcJsonOptions.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                //    mvcJsonOptions.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                //    //mvcJsonOptions.SerializerSettings.DateFormatString = "U";
                //    mvcJsonOptions.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                //    mvcJsonOptions.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                //    mvcJsonOptions.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                //});

            //Register implementations for Depedency Injection here.
            serviceCollection.AddSingleton<AuthenticationAuthorityStrategyFactory>();
            serviceCollection.AddSingleton<InformationSnippet>();
            serviceCollection.AddSingleton<UserBridgeFactory>();
            serviceCollection.AddTransient<AuthenticationHeaderHandler>();
            serviceCollection.AddTransient<IAuthenticationStoreStrategy, AuthenticationStoreHttpContextStrategy>();
            serviceCollection.AddTransient<IAuthenticationTokenStrategy, AuthenticationTokenJwtBearerStrategy>();
            serviceCollection.AddTransient<IGameProxy, GameProxy>();
            serviceCollection.AddTransient<IGameService, GameService>();
            serviceCollection.AddTransient<IUserProxy, UserProxy>();
            serviceCollection.AddTransient<IUserService, UserService>();

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