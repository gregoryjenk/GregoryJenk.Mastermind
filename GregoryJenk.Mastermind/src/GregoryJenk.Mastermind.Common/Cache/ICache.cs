using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Common.Cache
{
    public interface ICache<VM>
    {
        bool Any(string key);
        VM Get(string key);
        void Set(VM viewModel);
    }
}