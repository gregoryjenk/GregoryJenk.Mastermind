using GregoryJenk.Mastermind.Message.Extensions.Users;
using GregoryJenk.Mastermind.Message.ViewModels.Games;
using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult Create([FromBody] GameViewModel gameViewModel)
        {
            gameViewModel = _gameServiceClient.Create(gameViewModel);

            return Created(string.Format("api/game/{0}", gameViewModel.Id), gameViewModel);
        }

        [HttpPut, Route("{id}/state")]
        public IActionResult UpdateState(Guid id, [FromBody] GameViewModel gameViewModel)
        {
            gameViewModel = _gameServiceClient.UpdateState(id, gameViewModel);

            return Ok(gameViewModel);
        }

        [HttpGet, Route("{id}")]
        public IActionResult ReadById(Guid id)
        {
            GameViewModel gameViewModel = _gameServiceClient.ReadById(id);

            return Ok(gameViewModel);
        }

        [HttpGet, Route("")]
        public IActionResult ReadAll()
        {
            IList<GameViewModel> gameViewModels = _gameServiceClient.ReadAll();

            return Ok(gameViewModels);
        }
    }
}