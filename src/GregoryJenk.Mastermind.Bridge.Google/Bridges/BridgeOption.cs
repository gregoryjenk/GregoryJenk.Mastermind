using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Bridge.Google.Bridges
{
    public class BridgeOption
    {
        public Uri BaseUrl { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public Uri RedirectUrl { get; set; }
    }
}