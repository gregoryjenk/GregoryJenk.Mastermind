using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Service.Bridges.Users
{
    public interface IUserBridge
    {
        Task<UserViewModel> ReadByCodeAsync(string code);
    }
}