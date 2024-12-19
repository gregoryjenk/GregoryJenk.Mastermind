using GregoryJenk.Mastermind.Message.ViewModels.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Service.Proxies.Users
{
    public class UserProxy : IUserProxy
    {
        public async Task<UserViewModel> UpsertAsync()
        {
            throw new NotImplementedException();
        }
    }
}