using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Memory.Caches
{
    public abstract class BaseCache<M, MKey>
    {
        protected readonly IMemoryCache _memoryCache;

        protected BaseCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public M ReadByKey(MKey key)
        {
            return _memoryCache.Get<M>(key);
        }

        //Could have the abstract generate method here, so it could be used here
        //and also implemented in the concrete class for the interface.
        //public abstract MKey GenerateKey(M message);

        public void Upsert(MKey key, M message)
        {
            _memoryCache.Set(key, message);
        }

        public void DeleteByKey(MKey key)
        {
            _memoryCache.Remove(key);
        }
    }
}