using GregoryJenk.Mastermind.Web.Mvc.Factories.Users;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc
{
    public class DefaultController : Controller
    {
        private readonly ExternalUserServiceClientFactory _externalUserServiceClientFactory;

        public DefaultController(ExternalUserServiceClientFactory externalUserServiceClientFactory)
        {
            _externalUserServiceClientFactory = externalUserServiceClientFactory;
        }

        [HttpGet, Route("/error")]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet, Route("/external")]
        public IActionResult External(string authenticationScheme)
        {
            IExternalUserServiceClient externalUserServiceClient = _externalUserServiceClientFactory.Create(authenticationScheme);

            Uri authorisationUrl = externalUserServiceClient.ReadAuthoriseUri();

            return new RedirectResult(authorisationUrl.AbsoluteUri);
        }

        [HttpGet, Route("/"), Route("{*url}")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet, Route("/login-google")]
        public IActionResult LoginGoogle()
        {
            IExternalUserServiceClient externalUserServiceClient = _externalUserServiceClientFactory.Create("google");

            return View();
        }

        [Authorize, HttpGet, Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");

            return Redirect("/login");
        }

        //[HttpGet, Route("/not-found")]
        //TODO: public IActionResult NotFound()
        //{
        //    return View();
        //}

        [HttpGet, Route("/privacy-policy")]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        [HttpGet, Route("/terms-and-conditions")]
        public IActionResult TermsAndConditions()
        {
            return View();
        }
    }
}