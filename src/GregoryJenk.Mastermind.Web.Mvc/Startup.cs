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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            serviceCollection.AddApplicationInsightsTelemetry();

            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer((JwtBearerOptions jwtBearerOptions) =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:JwtBearer:IssuerSigningKey"])),
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidAudience = _configuration["Authentication:JwtBearer:ValidAudience"],
                        ValidIssuer = "GregoryJenk.Mastermind.Web.Mvc"
                    };
                });

            serviceCollection.AddAutoMapper((IMapperConfigurationExpression mapperConfigurationExpression) =>
            {
                mapperConfigurationExpression.AddProfile<UserViewModelProfile>();
            });

            serviceCollection.AddControllersWithViews((MvcOptions mvcOptions) =>
            {
                mvcOptions.RespectBrowserAcceptHeader = true;
            });

            serviceCollection.AddHttpClient(ProxyConstant.DefaultName)
                .AddHttpMessageHandler<AuthenticationHeaderHandler>();

            serviceCollection.AddHttpContextAccessor();

            serviceCollection.AddScoped<AuthenticationHeaderHandler>();
            serviceCollection.AddScoped<IAuthenticationStoreStrategy, AuthenticationStoreHttpContextStrategy>();
            serviceCollection.AddScoped<IAuthenticationTokenStrategy, AuthenticationTokenJwtBearerStrategy>();
            serviceCollection.AddScoped<IGameProxy, GameProxy>();
            serviceCollection.AddScoped<IGameService, GameService>();
            serviceCollection.AddScoped<IUserProxy, UserProxy>();
            serviceCollection.AddScoped<IUserService, UserService>();

            serviceCollection.AddSignalR();

            serviceCollection.AddSingleton<AuthenticationAuthorityStrategyFactory>();
            serviceCollection.AddSingleton<InformationSnippet>();
            serviceCollection.AddSingleton<UserBridgeFactory>();

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
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
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

            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseRouting();

            applicationBuilder.UseAuthentication();

            applicationBuilder.UseAuthorization();

            applicationBuilder.UseEndpoints((IEndpointRouteBuilder endpointRouteBuilder) =>
            {
                endpointRouteBuilder.MapControllers();

                endpointRouteBuilder.MapHub<GameHub>("hub/game");
            });
        }
    }
}