using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Options.Authentication.Jwt
{
    public class JwtAuthenticationOption
    {
        public string IssuerSigningKey { get; set; }
        public string ValidAudience { get; set; }
    }
}