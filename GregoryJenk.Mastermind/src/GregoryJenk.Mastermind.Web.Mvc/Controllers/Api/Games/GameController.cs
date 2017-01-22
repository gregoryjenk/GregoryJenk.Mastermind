using GregoryJenk.Mastermind.Message.ViewModels.Games;
using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Web.Mvc.Extensions.Users;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Controllers.Api.Games
{
    [Authorize, Route("/api/game")]
    public class GameController : Controller
    {
        private readonly IGameServiceClient _gameServiceClient;

        public GameController(IGameServiceClient gameServiceClient)
        {
            _gameServiceClient = gameServiceClient;
        }

        [HttpPost, Route("")]
        public IActionResult Create([FromBody] GameViewModel game)
        {
            UserViewModel user = new UserViewModel();

            user.ConvertPrincipal(User);

            //TODO: Create game.

            return Created(string.Format("api/game/{0}", game.Id), game);
        }
    }
}