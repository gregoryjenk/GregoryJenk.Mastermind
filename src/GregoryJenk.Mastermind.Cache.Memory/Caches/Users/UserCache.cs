﻿using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Memory.Caches.Users
{
    public class UserCache : BaseCache<UserViewModel, Guid>, IUserCache
    {

    }
}