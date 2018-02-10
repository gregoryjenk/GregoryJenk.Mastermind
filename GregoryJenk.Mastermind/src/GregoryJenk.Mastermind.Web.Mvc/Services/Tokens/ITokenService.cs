using GregoryJenk.Mastermind.Message.ViewModels.Tokens;
using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Services.Tokens
{
    public interface ITokenService
    {
        TokenViewModel Create(UserViewModel userViewModel, string scheme);
        void Delete();
        TokenViewModel Read();
    }
}