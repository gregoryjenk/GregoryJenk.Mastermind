using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Strategies.Authentication
{
    public class AuthenticationAuthorityGoogleStrategyOption
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public Uri RedirectUrl { get; set; }
    }
}