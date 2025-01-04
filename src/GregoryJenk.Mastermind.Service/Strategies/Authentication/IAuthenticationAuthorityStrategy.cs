using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Service.Strategies.Authentication
{
    public interface IAuthenticationAuthorityStrategy
    {
        Uri ReadUrl();
    }
}