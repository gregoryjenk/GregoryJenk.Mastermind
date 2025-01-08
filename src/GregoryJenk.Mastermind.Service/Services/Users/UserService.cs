using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Service.Bridges.Users;
using GregoryJenk.Mastermind.Service.Extensions.Users;
using GregoryJenk.Mastermind.Service.Proxies.Users;
using GregoryJenk.Mastermind.Service.Strategies.Authentication;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IAuthenticationTokenStrategy _authenticationTokenStrategy;
        private readonly IAuthenticationStoreStrategy _authenticationStoreStrategy;
        private readonly IUserProxy _userProxy;

        public UserService(IAuthenticationTokenStrategy authenticationTokenStrategy, IAuthenticationStoreStrategy authenticationStoreStrategy, IUserProxy userProxy)
        {
            _authenticationTokenStrategy = authenticationTokenStrategy;
            _authenticationStoreStrategy = authenticationStoreStrategy;
            _userProxy = userProxy;
        }

        public async Task<AuthenticationTokenStrategyResult> CreateTokenAsync(string scheme, string code, IUserBridge userBridge)
        {
            var bridgedUserViewModel = await userBridge.ReadByCodeAsync(code);

            bridgedUserViewModel.Scheme = scheme;

            var initialAuthenticationTokenStrategyResult = _authenticationTokenStrategy.Create(bridgedUserViewModel);

            _authenticationStoreStrategy.Set(initialAuthenticationTokenStrategyResult);

            var userViewModel = await _userProxy.ReadAsync();

            if (userViewModel is null)
            {
                userViewModel = new UserViewModel();
            }

            userViewModel.Set(bridgedUserViewModel);

            var intermediateAuthenticationTokenStrategyResult = _authenticationTokenStrategy.Create(userViewModel);

            _authenticationStoreStrategy.Set(intermediateAuthenticationTokenStrategyResult);

            userViewModel = await _userProxy.UpsertAsync();

            var actualAuthenticationTokenStrategyResult = _authenticationTokenStrategy.Create(userViewModel);

            _authenticationStoreStrategy.Set(actualAuthenticationTokenStrategyResult, true);

            return actualAuthenticationTokenStrategyResult;
        }
    }
}