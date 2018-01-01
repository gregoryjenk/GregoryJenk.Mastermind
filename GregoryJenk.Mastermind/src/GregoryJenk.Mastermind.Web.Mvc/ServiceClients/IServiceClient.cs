using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients
{
    public interface IServiceClient<VM, VmId> : IReadOnlyServiceClient<VM, VmId>
    {
        VM Create(VM viewModel);
        VM Update(VmId id, VM viewModel);
        void Delete(VmId id);
    }
}