using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Web.Mvc.Extensions.Users;
using GregoryJenk.Mastermind.Web.Mvc.Factories.Users;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Controllers.Api.Users
{
    [Route("/api/user")] //TODO: Authorize.
    public class UserController : Controller
    {
        private readonly ExternalUserServiceClientFactory _externalUserServiceClientFactory;

        public UserController(ExternalUserServiceClientFactory externalUserServiceClientFactory)
        {
            _externalUserServiceClientFactory = externalUserServiceClientFactory;
        }

        [HttpGet, Route("")]
        public IActionResult Read()
        {
            UserViewModel user = new UserViewModel();

            user.ConvertPrincipal(User);

            IExternalUserServiceClient externalUserServiceClient = _externalUserServiceClientFactory.Create(user.Scheme);

            //TODO: This should really only be done on login and saved.
            ExternalUserViewModel externalUser = externalUserServiceClient.ReadById(user.ExternalId);

            user.Image = externalUser.Image;

            return Ok(user);
        }
    }
}