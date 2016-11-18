using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;
using System.Security.Claims;

namespace GregoryJenk.Mastermind.Web.Mvc.Extensions.Users
{
    public static class UserViewModelExtension
    {
        /// <summary>
        /// Converts claims from within the current context into the user view model.
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <param name="claimsPrincipal"></param>
        public static void Convert(this UserViewModel userViewModel, ClaimsPrincipal claimsPrincipal)
        {
            userViewModel.Name = claimsPrincipal.Claims.Single(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
            userViewModel.Email = claimsPrincipal.Claims.Single(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
        }
    }
}