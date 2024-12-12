using GregoryJenk.Mastermind.Message.Caches.Users;
using GregoryJenk.Mastermind.Message.ViewModels.Users;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Redis.Caches.Users
{
    public class UserViewModelCache : BaseCache<UserViewModel, string>, IUserViewModelCache
    {
        public UserViewModelCache(IDistributedCache distributedCache)
            : base(distributedCache)
        {

        }

        public string GenerateKey(UserViewModel userViewModel)
        {
            return $"user:{userViewModel.Id}";
        }
    }
}