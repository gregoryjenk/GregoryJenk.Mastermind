using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Globalization;
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
            var createdClaim = claimsPrincipal.Claims.Single(claim => claim.Type == "Created");
            var updatedClaim = claimsPrincipal.Claims.Single(claim => claim.Type == "Updated");
            var deletedClaim = claimsPrincipal.Claims.Single(claim => claim.Type == "Deleted");
            var versionClaim = claimsPrincipal.Claims.Single(claim => claim.Type == ClaimTypes.Version);
            var emailClaim = claimsPrincipal.Claims.Single(claim => claim.Type == ClaimTypes.Email);
            var schemeClaim = claimsPrincipal.Claims.Single(claim => claim.Type == "Scheme");
            var imageClaim = claimsPrincipal.Claims.Single(claim => claim.Type == "Image");
            var externalIdClaim = claimsPrincipal.Claims.Single(claim => claim.Type == "ExternalId");

            var enAuCultureInfo = new CultureInfo("en-AU");

            DateTimeOffset? updated;
            DateTimeOffset? deleted;

            if (!string.IsNullOrEmpty(updatedClaim.Value))
            {
                updated = DateTimeOffset.Parse(updatedClaim.Value, enAuCultureInfo);
            }
            else
            {
                updated = null;
            }

            if (!string.IsNullOrEmpty(deletedClaim.Value))
            {
                deleted = DateTimeOffset.Parse(deletedClaim.Value, enAuCultureInfo);
            }
            else
            {
                deleted = null;
            }

            userViewModel.Id = Guid.Parse(sidClaim.Value);
            userViewModel.Created = DateTimeOffset.Parse(createdClaim.Value, enAuCultureInfo);
            userViewModel.Updated = updated;
            userViewModel.Deleted = deleted;
            userViewModel.Version = int.Parse(versionClaim.Value);
            userViewModel.Name = claimsPrincipal.Identity.Name;
            userViewModel.Email = emailClaim.Value;
            userViewModel.Scheme = schemeClaim.Value;
            userViewModel.Image = imageClaim.Value;
            userViewModel.ExternalId = externalIdClaim.Value;
        }
    }
}