using GregoryJenk.Mastermind.Message.ViewModels.Tokens;
using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users
{
    public interface IUserServiceClient
    {
        UserViewModel Upsert();
        //TODO: Refactor this into a segregated interface.
        void IncludeAuthorisationHeader(TokenViewModel tokenViewModel);
    }
}