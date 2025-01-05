using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Service.Strategies.Authentication
{
    public class AuthenticationTokenStrategyResult
    {
        public string Scheme { get; set; }

        public string Token { get; set; }

        public DateTimeOffset Expiry { get; set; }
    }
}