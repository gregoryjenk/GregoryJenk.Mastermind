using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Web.Mvc.Extensions.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Controllers.Api.Users
{
    [ApiController, Authorize, Route("api/user")]
    public class UserController : ControllerBase
    {
        [HttpGet, Route("")]
        public IActionResult Read()
        {
            var userViewModel = new UserViewModel();

            userViewModel.SetByClaimsPrincipal(User);

            return Ok(userViewModel);
        }
    }
}