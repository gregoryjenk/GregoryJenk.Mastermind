using GregoryJenk.Mastermind.Message.ViewModels.Games;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Games;
using GregoryJenk.Mastermind.Web.Mvc.Services.Tokens;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Games
{
    public class GameServiceClient : BaseServiceClient<GameViewModel, Guid>, IGameServiceClient
    {
        public GameServiceClient(ITokenService tokenService, IOptions<GameServiceOption> gameServiceOption)
            : base(tokenService, gameServiceOption.Value.BaseUrl, "game")
        {
            
        }
    }
}