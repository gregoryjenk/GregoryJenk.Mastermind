using GregoryJenk.Mastermind.Message.ViewModels;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.InMemory.Caches
{
    public abstract class BaseCache<VM, VmId> where VM : BaseEntityViewModel<VmId>
    {
        public BaseCache()
        {

        }

        public bool Any(string key)
        {
            return false;
        }

        public VM Get(string key)
        {
            return null;
        }

        public void Set(VM viewModel)
        {

        }
    }
}