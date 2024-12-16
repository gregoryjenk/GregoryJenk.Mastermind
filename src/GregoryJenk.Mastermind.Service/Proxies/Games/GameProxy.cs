using GregoryJenk.Mastermind.Message.Requests.Games;
using GregoryJenk.Mastermind.Message.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Service.Proxies.Games
{
    public class GameProxy : IGameProxy
    {
        public async Task<GameViewModel> ReadByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GameViewModel> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<GameViewModel>> ReadByDecoderUserIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GameViewModel> CreateGuessAsync(GameCreateGuessRequest gameCreateGuessRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<GameViewModel> UpdateStateAsync(GameUpdateStateRequest gameUpdateStateRequest)
        {
            throw new NotImplementedException();
        }
    }
}