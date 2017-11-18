using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Services.Tokens
{
    public interface ITokenService
    {
        void Create(UserViewModel userViewModel, string scheme);
        void Delete();
    }
}