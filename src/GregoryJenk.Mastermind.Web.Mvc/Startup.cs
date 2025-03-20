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
                    var issuerSigningKey = _configuration["Authentication:JwtBearer:IssuerSigningKey"];
                    var validAudience = _configuration["Authentication:JwtBearer:ValidAudience"];

                    var issuerSigningKeyBytes = Encoding.UTF8.GetBytes(issuerSigningKey);

                    var symmetricSecurityKey = new SymmetricSecurityKey(issuerSigningKeyBytes);

                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = symmetricSecurityKey,
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidAudience = validAudience,
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

            serviceCollection.Configure<AuthenticationAuthorityGoogleStrategyOption>(_configuration.GetSection("Authentication:Google"));
            serviceCollection.Configure<AuthenticationTokenJwtBearerStrategyOption>(_configuration.GetSection("Authentication:JwtBearer"));
            serviceCollection.Configure<BridgeOption>(_configuration.GetSection("Bridge:Google:Bridges"));
            serviceCollection.Configure<ProxyOption>(_configuration.GetSection("Service:Proxies"));
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