using System;
using System.Collections.Generic;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients
{
    public interface IReadOnlyServiceClient<VM, VmId>
    {
        VM ReadById(VmId id);
        IList<VM> ReadAll();
        IList<VM> ReadAll(int index, int count);
    }
}