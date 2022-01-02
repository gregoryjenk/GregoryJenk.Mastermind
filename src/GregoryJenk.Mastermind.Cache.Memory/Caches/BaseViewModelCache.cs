using GregoryJenk.Mastermind.Message.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Memory.Caches
{
    public abstract class BaseViewModelCache<VM, VmId, VmKey> where VM : BaseEntityViewModel<VmId>
    {
        public readonly IMemoryCache _memoryCache;

        public BaseViewModelCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Upsert(VmKey key, VM viewModel)
        {
            _memoryCache.Set(key, viewModel);
        }

        public VM ReadByKey(VmKey key)
        {
            return _memoryCache.Get<VM>(key);
        }

        //Could have the abstract generate method here, so it could be used here
        //and also implemented in the concrete class for the interface.
        //public abstract VmKey GenerateKey(VM viewModel);
    }
}