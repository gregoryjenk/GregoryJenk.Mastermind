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
        public static void SetByClaimsPrincipal(this UserViewModel userViewModel, ClaimsPrincipal claimsPrincipal)
        {
            var sidClaim = claimsPrincipal.Claims.Single(claim => claim.Type == ClaimTypes.Sid);
            var emailClaim = claimsPrincipal.Claims.Single(claim => claim.Type == ClaimTypes.Email);
            var schemeClaim = claimsPrincipal.Claims.Single(claim => claim.Type == "Scheme");
            var imageClaim = claimsPrincipal.Claims.Single(claim => claim.Type == "Image");
            var externalIdClaim = claimsPrincipal.Claims.Single(claim => claim.Type == "ExternalId");

            userViewModel.Id = Guid.Parse(sidClaim.Value);
            userViewModel.Name = claimsPrincipal.Identity.Name;
            userViewModel.Email = emailClaim.Value;
            userViewModel.Scheme = schemeClaim.Value;
            userViewModel.Image = imageClaim.Value;
            userViewModel.ExternalId = externalIdClaim.Value;
        }
    }
}