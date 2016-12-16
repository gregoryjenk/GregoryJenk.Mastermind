using GregoryJenk.Mastermind.Message.ViewModels.Games;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Games
{
    public interface IGameServiceClient : IServiceClient<GameViewModel, string>
    {

    }
}