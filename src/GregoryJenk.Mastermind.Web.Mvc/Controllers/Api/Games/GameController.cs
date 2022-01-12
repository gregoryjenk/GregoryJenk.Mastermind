using GregoryJenk.Mastermind.Message.Requests.Games.Guesses;
using GregoryJenk.Mastermind.Message.ViewModels.Games;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Controllers.Api.Games
{
    [ApiController, Authorize, Route("api/game")]
    public class GameController : ControllerBase
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

        [HttpPost, Route("{id}/guess")]
        public IActionResult CreateGuess(Guid id, [FromBody] GameGuessCreateRequest gameGuessCreateRequest)
        {
            var gameViewModel = _gameServiceClient.CreateGuess(id, gameGuessCreateRequest.Game, gameGuessCreateRequest.Guess);

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