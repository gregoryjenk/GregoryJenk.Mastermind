using GregoryJenk.Mastermind.Service.Services.Information;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Snippets.Information
{
    public class InformationSnippet
    {
        public InformationSnippet()
        {
            Version = InformationService.ReadVersionByEntryAssembly();
        }

        public string Version { get; private set; }
    }
}