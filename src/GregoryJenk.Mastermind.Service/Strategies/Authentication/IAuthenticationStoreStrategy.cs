using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Service.Strategies.Authentication
{
    public interface IAuthenticationStoreStrategy
    {
        AuthenticationStoreStrategyItem Get();

        void Set(AuthenticationTokenStrategyResult authenticationTokenStrategyResult, bool updateClient = false);
    }
}