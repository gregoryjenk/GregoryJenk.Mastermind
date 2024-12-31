using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Bridge.Google.Bridges
{
    public class BridgeOption
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public Uri RedirectUrl { get; set; }
    }
}