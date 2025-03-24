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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;

namespace GregoryJenk.Mastermind.Web.Mvc
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            webApplicationBuilder.Services.AddApplicationInsightsTelemetry();

            webApplicationBuilder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer((JwtBearerOptions jwtBearerOptions) =>
                {
                    var issuerSigningKey = webApplicationBuilder.Configuration["Authentication:JwtBearer:IssuerSigningKey"];
                    var validAudience = webApplicationBuilder.Configuration["Authentication:JwtBearer:ValidAudience"];

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

            webApplicationBuilder.Services.AddAutoMapper((IMapperConfigurationExpression mapperConfigurationExpression) =>
            {
                mapperConfigurationExpression.AddProfile<UserViewModelProfile>();
            });

            webApplicationBuilder.Services.AddControllersWithViews((MvcOptions mvcOptions) =>
            {
                mvcOptions.RespectBrowserAcceptHeader = true;
            });

            webApplicationBuilder.Services.AddHttpClient(ProxyConstant.DefaultName)
                .AddHttpMessageHandler<AuthenticationHeaderHandler>();

            webApplicationBuilder.Services.AddHttpContextAccessor();

            webApplicationBuilder.Services.AddScoped<AuthenticationHeaderHandler>();
            webApplicationBuilder.Services.AddScoped<IAuthenticationStoreStrategy, AuthenticationStoreHttpContextStrategy>();
            webApplicationBuilder.Services.AddScoped<IAuthenticationTokenStrategy, AuthenticationTokenJwtBearerStrategy>();
            webApplicationBuilder.Services.AddScoped<IGameProxy, GameProxy>();
            webApplicationBuilder.Services.AddScoped<IGameService, GameService>();
            webApplicationBuilder.Services.AddScoped<IUserProxy, UserProxy>();
            webApplicationBuilder.Services.AddScoped<IUserService, UserService>();

            webApplicationBuilder.Services.AddSignalR();

            webApplicationBuilder.Services.AddSingleton<AuthenticationAuthorityStrategyFactory>();
            webApplicationBuilder.Services.AddSingleton<InformationSnippet>();
            webApplicationBuilder.Services.AddSingleton<UserBridgeFactory>();

            webApplicationBuilder.Services.Configure<AuthenticationAuthorityGoogleStrategyOption>(webApplicationBuilder.Configuration.GetSection("Authentication:Google"));
            webApplicationBuilder.Services.Configure<AuthenticationTokenJwtBearerStrategyOption>(webApplicationBuilder.Configuration.GetSection("Authentication:JwtBearer"));
            webApplicationBuilder.Services.Configure<BridgeOption>(webApplicationBuilder.Configuration.GetSection("Bridge:Google:Bridges"));
            webApplicationBuilder.Services.Configure<ProxyOption>(webApplicationBuilder.Configuration.GetSection("Service:Proxies"));

            var webApplication = webApplicationBuilder.Build();

            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.UseDeveloperExceptionPage();
            }
            else
            {
                webApplication.UseExceptionHandler("/error");

                webApplication.UseHsts();
            }

            webApplication.UseHttpsRedirection();

            webApplication.UseStaticFiles();

            webApplication.UseRouting();

            webApplication.UseAuthentication();

            webApplication.UseAuthorization();

            webApplication.UseEndpoints((IEndpointRouteBuilder endpointRouteBuilder) =>
            {
                endpointRouteBuilder.MapControllers();

                endpointRouteBuilder.MapHub<GameHub>("hub/game");
            });

            webApplication.Run();
        }
    }
}