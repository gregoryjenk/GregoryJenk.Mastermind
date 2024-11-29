using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging((ILoggingBuilder loggingBuilder) =>
                {
                    loggingBuilder.ClearProviders();

                    loggingBuilder.AddConsole();

                    //loggingBuilder.SetMinimumLevel(LogLevel.Information);
                })
                .ConfigureWebHostDefaults((IWebHostBuilder webHostBuilder) =>
                {
                    webHostBuilder.UseStartup<Startup>();
                });
        }
    }
}