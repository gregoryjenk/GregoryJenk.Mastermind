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
        public static void ConvertPrincipal(this UserViewModel userViewModel, ClaimsPrincipal claimsPrincipal)
        {
            userViewModel.Name = claimsPrincipal.Identity.Name;
            userViewModel.Email = claimsPrincipal.Claims.Single(c => c.Type == ClaimTypes.Email).Value;
            userViewModel.Scheme = claimsPrincipal.Identity.AuthenticationType;
            userViewModel.ExternalId = claimsPrincipal.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}