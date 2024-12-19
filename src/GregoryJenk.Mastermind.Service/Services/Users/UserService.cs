using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Service.Proxies.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserProxy _userProxy;

        public UserService(IUserProxy userProxy)
        {
            _userProxy = userProxy;
        }

        public async Task<UserViewModel> UpsertAsync()
        {
            return await _userProxy.UpsertAsync();
        }
    }
}