using GregoryJenk.Mastermind.Message.ViewModels.Games;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Games
{
    public interface IGameServiceClient : IServiceClient<GameViewModel, Guid>
    {
        GameViewModel CreateGuess(Guid id, GameViewModel gameViewModel, GuessViewModel guessViewModel);
        GameViewModel UpdateState(Guid id, GameViewModel gameViewModel);
    }
}