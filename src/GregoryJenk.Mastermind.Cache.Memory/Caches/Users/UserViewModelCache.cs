using GregoryJenk.Mastermind.Message.Caches.Users;
using GregoryJenk.Mastermind.Message.ViewModels.Users;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Memory.Caches.Users
{
    public class UserViewModelCache : BaseViewModelCache<UserViewModel, Guid, string>, IUserViewModelCache
    {
        public UserViewModelCache(IMemoryCache memoryCache)
            : base(memoryCache)
        {

        }

        public string GenerateKey(UserViewModel userViewModel)
        {
            return $"user:{userViewModel.Scheme}:{userViewModel.Id}";
        }
    }
}