using GregoryJenk.Mastermind.Message.ViewModels;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Redis.Caches
{
    public abstract class BaseCache<VM, VmId> where VM : BaseEntityViewModel<VmId>
    {
        public readonly IDistributedCache _distributedCache;

        public BaseCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public bool Any(string key)
        {
            throw new NotImplementedException();
        }

        public VM Get(string key)
        {
            var cacheJsonStringContent = _distributedCache.GetString(key);

            return JsonConvert.DeserializeObject<VM>(cacheJsonStringContent);
        }

        public void Set(string key, VM viewModel)
        {
            var distributedCacheEntryOptions = new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromHours(1)
            };

            _distributedCache.SetString(key, JsonConvert.SerializeObject(viewModel), distributedCacheEntryOptions);
        }
    }
}