using GregoryJenk.Mastermind.Message.Extensions.Users;
using GregoryJenk.Mastermind.Message.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Controllers.Api.Users
{
    [Authorize, Route("/api/user")]
    public class UserController : ControllerBase
    {
        [HttpGet, Route("")]
        public IActionResult Read()
        {
            UserViewModel userViewModel = new UserViewModel();

            userViewModel.ConvertPrincipal(User);

            return Ok(userViewModel);
        }
    }
}