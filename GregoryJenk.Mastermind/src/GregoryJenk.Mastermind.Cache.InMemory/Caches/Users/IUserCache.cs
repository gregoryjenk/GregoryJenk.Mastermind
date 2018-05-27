using GregoryJenk.Mastermind.Common.Cache;
using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.InMemory.Caches.Users
{
    //TODO: Consider moving this interface to a more sensible location.
    public interface IUserCache : ICache<UserViewModel>
    {

    }
}