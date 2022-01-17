using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Message.ViewModels.Users.Tokens;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Services.Users.Tokens
{
    public interface IUserTokenService
    {
        UserTokenViewModel Create(UserViewModel userViewModel, string scheme);

        void Delete();

        UserTokenViewModel Read();
    }
}