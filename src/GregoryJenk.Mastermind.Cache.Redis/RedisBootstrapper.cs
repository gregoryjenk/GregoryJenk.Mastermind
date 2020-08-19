using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Redis
{
    public static class RedisBootstrapper
    {
        public static void ConfigureRedis(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDistributedRedisCache(setupAction =>
            {
                setupAction.Configuration = "localhost";
                setupAction.InstanceName = "DefaultInstance";
            });
        }
    }
}