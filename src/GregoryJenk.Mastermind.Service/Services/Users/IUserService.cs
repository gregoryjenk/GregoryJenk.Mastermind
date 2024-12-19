using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Service.Services.Users
{
    public interface IUserService
    {
        Task<UserViewModel> UpsertAsync();
    }
}