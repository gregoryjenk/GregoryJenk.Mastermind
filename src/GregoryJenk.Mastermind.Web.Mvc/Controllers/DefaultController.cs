using GregoryJenk.Mastermind.Service.Services.Users;
using GregoryJenk.Mastermind.Web.Mvc.Factories;
using GregoryJenk.Mastermind.Web.Mvc.Factories.Authentication;
using GregoryJenk.Mastermind.Web.Mvc.Factories.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Web.Mvc.Controllers
{
    [AllowAnonymous, Route("")]
    public class DefaultController : Controller
    {
        private readonly AuthenticationAuthorityStrategyFactory _authenticationAuthorityStrategyFactory;
        private readonly UserBridgeFactory _userBridgeFactory;
        private readonly IUserService _userService;

        public DefaultController(AuthenticationAuthorityStrategyFactory authenticationAuthorityStrategyFactory, UserBridgeFactory userBridgeFactory, IUserService userService)
        {
            _authenticationAuthorityStrategyFactory = authenticationAuthorityStrategyFactory;
            _userBridgeFactory = userBridgeFactory;
            _userService = userService;
        }

        [HttpGet, Route("login-external")]
        public IActionResult LoginExternal(string scheme)
        {
            var authenticationAuthorityStrategy = _authenticationAuthorityStrategyFactory.Create(scheme);

            var authenticationAuthorityStrategyUrl = authenticationAuthorityStrategy.ReadUrl();

            return Redirect(authenticationAuthorityStrategyUrl.AbsoluteUri);
        }

        [HttpGet, Route("login-google")]
        public async Task<IActionResult> LoginGoogleAsync(string code)
        {
            var scheme = FactoryConstant.GoogleScheme;

            var userBridge = _userBridgeFactory.Create(scheme);

            await _userService.CreateTokenAsync(scheme, code, userBridge);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("privacy-policy")]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        [HttpGet, Route("terms-of-service")]
        public IActionResult TermsOfService()
        {
            return View();
        }

        [HttpGet, Route("error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}