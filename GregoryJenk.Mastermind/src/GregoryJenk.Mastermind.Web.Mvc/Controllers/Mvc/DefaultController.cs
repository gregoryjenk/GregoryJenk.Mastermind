using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Web.Mvc.Factories.Users;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users;
using GregoryJenk.Mastermind.Web.Mvc.Services.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;

namespace GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc
{
    public class DefaultController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IUserServiceClient _userServiceClient;
        private readonly ExternalUserServiceClientFactory _externalUserServiceClientFactory;

        public DefaultController(ITokenService tokenService, IUserServiceClient userServiceClient, ExternalUserServiceClientFactory externalUserServiceClientFactory)
        {
            _tokenService = tokenService;
            _userServiceClient = userServiceClient;
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
            var assemblyInformationalVersionAttribute = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>();

            ViewBag.Version = assemblyInformationalVersionAttribute.InformationalVersion;

            return View();
        }

        [HttpGet, Route("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet, Route("/login-google")]
        public IActionResult LoginGoogle(string code)
        {
            try
            {
                IExternalUserServiceClient externalUserServiceClient = _externalUserServiceClientFactory.Create("google");

                UserViewModel userViewModel = externalUserServiceClient.ReadByCode(code);

                _tokenService.Create(userViewModel, "google");

                _userServiceClient.Upsert();

                return Redirect("/");
            }
            catch (Exception ex)
            {
                _tokenService.Delete();

                return Redirect("/error");
            }
        }

        [Authorize, HttpGet, Route("/logout")]
        public IActionResult Logout()
        {
            _tokenService.Delete();

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