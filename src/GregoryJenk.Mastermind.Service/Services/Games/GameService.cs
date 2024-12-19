using GregoryJenk.Mastermind.Message.Requests.Games;
using GregoryJenk.Mastermind.Message.ViewModels.Games;
using GregoryJenk.Mastermind.Service.Proxies.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Service.Services.Games
{
    public class GameService : IGameService
    {
        private readonly IGameProxy _gameProxy;

        public GameService(IGameProxy gameProxy)
        {
            _gameProxy = gameProxy;
        }

        public async Task<GameViewModel> ReadByIdAsync(Guid id)
        {
            return await _gameProxy.ReadByIdAsync(id);
        }

        public async Task<GameViewModel> CreateAsync()
        {
            return await _gameProxy.CreateAsync();
        }

        public async Task<IList<GameViewModel>> ReadByDecoderUserIdAsync()
        {
            return await _gameProxy.ReadByDecoderUserIdAsync();
        }

        public async Task<GameViewModel> CreateGuessAsync(GameCreateGuessRequest gameCreateGuessRequest)
        {
            return await _gameProxy.CreateGuessAsync(gameCreateGuessRequest);
        }

        public async Task<GameViewModel> UpdateStateAsync(GameUpdateStateRequest gameUpdateStateRequest)
        {
            return await _gameProxy.UpdateStateAsync(gameUpdateStateRequest);
        }
    }
}