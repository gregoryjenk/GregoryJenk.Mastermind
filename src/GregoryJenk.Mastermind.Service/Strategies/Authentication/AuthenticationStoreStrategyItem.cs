using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Service.Strategies.Authentication
{
    public class AuthenticationStoreStrategyItem
    {
        public string Scheme { get; set; }

        public string Token { get; set; }
    }
}