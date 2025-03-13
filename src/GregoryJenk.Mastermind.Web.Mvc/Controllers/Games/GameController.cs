using GregoryJenk.Mastermind.Message.Requests.Games;
using GregoryJenk.Mastermind.Service.Services.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Web.Mvc.Controllers.Games
{
    [ApiController, Authorize, Route("api/game")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> ReadByIdAsync(Guid id)
        {
            var gameViewModel = await _gameService.ReadByIdAsync(id);

            return Ok(gameViewModel);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> CreateAsync()
        {
            var gameViewModel = await _gameService.CreateAsync();

            var location = new Uri($"{Request.Scheme}://{Request.Host}/api/game/{gameViewModel.Id}");

            return Created(location, gameViewModel);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> ReadByDecoderUserIdAsync()
        {
            var gameViewModels = await _gameService.ReadByDecoderUserIdAsync();

            return Ok(gameViewModels);
        }

        [HttpPost, Route("{id}/guess")]
        public async Task<IActionResult> CreateGuessAsync(Guid id, [FromBody] GameCreateGuessRequest gameCreateGuessRequest)
        {
            var gameViewModel = await _gameService.CreateGuessAsync(gameCreateGuessRequest);

            var location = new Uri($"{Request.Scheme}://{Request.Host}/api/game/{gameViewModel.Id}");

            return Created(location, gameViewModel);
        }

        [HttpPut, Route("{id}/state")]
        public async Task<IActionResult> UpdateStateAsync(Guid id, [FromBody] GameUpdateStateRequest gameUpdateStateRequest)
        {
            var gameViewModel = await _gameService.UpdateStateAsync(gameUpdateStateRequest);

            return Ok(gameViewModel);
        }
    }
}