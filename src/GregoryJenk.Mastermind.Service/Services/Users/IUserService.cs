using GregoryJenk.Mastermind.Service.Bridges.Users;
using GregoryJenk.Mastermind.Service.Strategies.Authentication;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Service.Services.Users
{
    public interface IUserService
    {
        Task<AuthenticationTokenStrategyResult> CreateTokenAsync(string scheme, string code, IUserBridge userBridge);
    }
}