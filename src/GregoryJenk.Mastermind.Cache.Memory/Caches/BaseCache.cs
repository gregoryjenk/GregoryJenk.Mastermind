using GregoryJenk.Mastermind.Message.ViewModels;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Cache.Memory.Caches
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

        public void Set(string key, VM viewModel)
        {

        }
    }
}