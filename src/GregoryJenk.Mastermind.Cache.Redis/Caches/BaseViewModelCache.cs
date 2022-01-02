using GregoryJenk.Mastermind.Message.ViewModels;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Redis.Caches
{
    public abstract class BaseViewModelCache<VM, VmId, VmKey> where VM : BaseEntityViewModel<VmId>
    {
        public readonly IDistributedCache _distributedCache;

        public BaseViewModelCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void Upsert(VmKey key, VM viewModel)
        {
            var distributedCacheEntryOptions = new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromHours(1)
            };

            _distributedCache.SetString(Convert.ToString(key), JsonConvert.SerializeObject(viewModel), distributedCacheEntryOptions);
        }

        public VM ReadByKey(VmKey key)
        {
            var distributedCacheEntryJson = _distributedCache.GetString(Convert.ToString(key));

            return JsonConvert.DeserializeObject<VM>(distributedCacheEntryJson);
        }

        //Could have the abstract generate method here, so it could be used here
        //and also implemented in the concrete class for the interface.
        //public abstract VmKey GenerateKey(VM viewModel);
    }
}