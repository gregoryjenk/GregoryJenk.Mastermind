using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;
using System.Security.Claims;

namespace GregoryJenk.Mastermind.Web.Mvc.Extensions.Users
{
    //TODO: Consider relocating this to the message project since it's on the user view model.
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
            userViewModel.Scheme = claimsPrincipal.Claims.Single(c => c.Type == "Scheme").Value;
            userViewModel.ExternalId = claimsPrincipal.Claims.Single(c => c.Type == "ExternalId").Value;
            userViewModel.Image = claimsPrincipal.Claims.Single(c => c.Type == "Image").Value;
        }
    }
}