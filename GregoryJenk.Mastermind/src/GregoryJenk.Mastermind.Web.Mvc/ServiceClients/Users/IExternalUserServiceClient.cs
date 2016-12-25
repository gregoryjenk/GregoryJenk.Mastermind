using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users
{
    public interface IExternalUserServiceClient : IReadOnlyServiceClient<ExternalUserViewModel, string>
    {

    }
}