using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Strategies.Authentication
{
    public class AuthenticationTokenJwtBearerStrategyOption
    {
        public string IssuerSigningKey { get; set; }

        public string ValidAudience { get; set; }
    }
}