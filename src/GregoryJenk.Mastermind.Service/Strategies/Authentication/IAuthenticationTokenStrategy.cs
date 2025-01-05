using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Service.Strategies.Authentication
{
    public interface IAuthenticationTokenStrategy
    {
        AuthenticationTokenStrategyResult Create(UserViewModel userViewModel);
    }
}