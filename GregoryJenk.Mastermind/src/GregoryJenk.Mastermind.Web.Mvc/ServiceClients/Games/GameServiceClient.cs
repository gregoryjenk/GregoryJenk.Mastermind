using GregoryJenk.Mastermind.Message.ViewModels.Games;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Games;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Games
{
    public class GameServiceClient : BaseServiceClient<GameViewModel, Guid>, IGameServiceClient
    {
        public GameServiceClient(IOptions<GameServiceOption> gameServiceOption)
            : base(gameServiceOption.Value.BaseUrl, "game")
        {
            
        }
    }
}