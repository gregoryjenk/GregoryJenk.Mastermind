using GregoryJenk.Mastermind.Message.Requests.Games;
using GregoryJenk.Mastermind.Message.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Service.Services.Games
{
    public interface IGameService
    {
        Task<GameViewModel> ReadByIdAsync(Guid id);

        Task<GameViewModel> CreateAsync();

        Task<IList<GameViewModel>> ReadByDecoderUserIdAsync();

        Task<GameViewModel> CreateGuessAsync(GameCreateGuessRequest gameCreateGuessRequest);

        Task<GameViewModel> UpdateStateAsync(GameUpdateStateRequest gameUpdateStateRequest);
    }
}