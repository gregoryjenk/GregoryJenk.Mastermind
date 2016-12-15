using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients
{
    public interface IServiceClient<VM, VmId> : IReadOnlyServiceClient<VM, VmId>
    {
        VmId Create(VM viewModel);
        void Update(VmId id, VM viewModel);
        void Delete(VmId id);
    }
}