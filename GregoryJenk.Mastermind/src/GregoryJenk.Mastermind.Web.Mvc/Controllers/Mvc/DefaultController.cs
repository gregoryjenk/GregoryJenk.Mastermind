﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc
{
    public class DefaultController : Controller
    {
        [HttpGet, Route("/error")]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet, Route("/external")]
        public IActionResult External(string authenticationScheme)
        {
            var authenticationProperties = new AuthenticationProperties()
            {
                RedirectUri = "/"
            };

            //TODO: Check that the user has been saved.

            return new ChallengeResult(authenticationScheme, authenticationProperties);
        }

        [Authorize, HttpGet, Route("/"), Route("{*url}")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("/login")]
        public IActionResult Login()
        {
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