using System;
using System.Linq;
using System.Reflection;

namespace GregoryJenk.Mastermind.Service.Services.Information
{
    public static class InformationService
    {
        public static string ReadVersionByEntryAssembly()
        {
            var assemblyInformationalVersionAttribute = Assembly.GetEntryAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>();

            return assemblyInformationalVersionAttribute.InformationalVersion;
        }
    }
}