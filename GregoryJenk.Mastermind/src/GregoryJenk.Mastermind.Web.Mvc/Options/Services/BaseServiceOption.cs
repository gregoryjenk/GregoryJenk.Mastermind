using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Options.Services
{
    public abstract class BaseServiceOption
    {
        public Uri BaseUrl { get; set; }
        public string Key { get; set; }
    }
}