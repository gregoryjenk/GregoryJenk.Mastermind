﻿using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Redis.Caches.Users
{
    public class UserCache : BaseCache<UserViewModel, string>, IUserCache
    {

    }
}