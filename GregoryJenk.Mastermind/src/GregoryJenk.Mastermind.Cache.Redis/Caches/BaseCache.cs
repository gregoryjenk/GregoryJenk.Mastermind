//using Microsoft.Extensions.Caching.Distributed;
//using Microsoft.Extensions.Caching.Redis;
using GregoryJenk.Mastermind.Message.ViewModels;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Redis.Caches
{
    public abstract class BaseCache<VM, VmId> where VM : BaseEntityViewModel<VmId>
    {
        public BaseCache()
        {
            
        }
    }
}