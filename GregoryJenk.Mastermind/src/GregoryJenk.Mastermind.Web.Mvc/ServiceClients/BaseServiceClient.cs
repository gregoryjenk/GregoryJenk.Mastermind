using GregoryJenk.Mastermind.Message.ViewModels;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients
{
    public abstract class BaseServiceClient<VM, VmId> where VM : BaseViewModel<VmId>
    {

    }
}