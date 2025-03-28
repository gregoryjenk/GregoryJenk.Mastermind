﻿using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Service.Proxies.Users
{
    public interface IUserProxy
    {
        Task<UserViewModel> ReadAsync();

        Task<UserViewModel> UpsertAsync();
    }
}