using GregoryJenk.Mastermind.Message.ViewModels.Users;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Redis.Caches.Users
{
    public class UserCache : BaseCache<UserViewModel, Guid>, IUserCache
    {
        public UserCache(IDistributedCache distributedCache)
            : base(distributedCache)
        {

        }
    }
}