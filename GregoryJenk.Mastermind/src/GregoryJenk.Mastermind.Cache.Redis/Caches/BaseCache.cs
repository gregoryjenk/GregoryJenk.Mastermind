//using Microsoft.Extensions.Caching.Distributed;
//using Microsoft.Extensions.Caching.Redis;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Redis.Caches
{
    public abstract class BaseCache<VM> //where VM : BaseEntityViewModel<VmId>
    {
        public BaseCache()
        {
            
        }
    }
}