using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Web.Mvc.Hubs.Games
{
    public class GameHub : Hub
    {
        public async Task NotifyStateAsync(string message)
        {
            await Clients.All.SendAsync("notifyState", message);
        }
    }
}