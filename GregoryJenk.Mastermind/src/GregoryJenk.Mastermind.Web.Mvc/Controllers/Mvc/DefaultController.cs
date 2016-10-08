using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace GregoryJenk.Mastermind.Web.Mvc.Controllers
{
    public class DefaultController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}