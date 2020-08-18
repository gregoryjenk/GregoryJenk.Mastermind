using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Options.Services
{
    public abstract class BaseServiceOption
    {
        public string ApiKey { get; set; }
        public Uri BaseUrl { get; set; }
    }
}