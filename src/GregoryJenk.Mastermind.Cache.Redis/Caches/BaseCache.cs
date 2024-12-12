using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Linq;
using System.Text.Json;

namespace GregoryJenk.Mastermind.Cache.Redis.Caches
{
    public abstract class BaseCache<M, MKey>
    {
        protected readonly IDistributedCache _distributedCache;

        protected BaseCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public M ReadByKey(MKey key)
        {
            var distributedCacheEntryKey = Convert.ToString(key);

            var distributedCacheEntryJson = _distributedCache.GetString(distributedCacheEntryKey);

            return JsonSerializer.Deserialize<M>(distributedCacheEntryJson);
        }

        //Could have the abstract generate method here, so it could be used here
        //and also implemented in the concrete class for the interface.
        //public abstract MKey GenerateKey(M message);

        public void Upsert(MKey key, M message)
        {
            var distributedCacheEntryKey = Convert.ToString(key);

            var distributedCacheEntryJson = JsonSerializer.Serialize(message);

            var distributedCacheEntryOptions = new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromHours(1)
            };

            _distributedCache.SetString(distributedCacheEntryKey, distributedCacheEntryJson, distributedCacheEntryOptions);
        }

        public void DeleteByKey(MKey key)
        {
            var distributedCacheEntryKey = Convert.ToString(key);

            _distributedCache.Remove(distributedCacheEntryKey);
        }
    }
}