using GregoryJenk.Mastermind.Service.Strategies.Authentication;
using GregoryJenk.Mastermind.Web.Mvc.Strategies.Authentication;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Factories.Authentication
{
    public class AuthenticationAuthorityStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public AuthenticationAuthorityStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IAuthenticationAuthorityStrategy Create(string scheme)
        {
            if (string.Equals(scheme, FactoryConstant.GoogleScheme, StringComparison.InvariantCultureIgnoreCase))
            {
                //Not ideal to have this service locator type approach, another way is to inject the options into the factory.
                var authenticationAuthorityGoogleStrategyOption = _serviceProvider.GetService(typeof(IOptions<AuthenticationAuthorityGoogleStrategyOption>)) as IOptions<AuthenticationAuthorityGoogleStrategyOption>;

                return new AuthenticationAuthorityGoogleStrategy(authenticationAuthorityGoogleStrategyOption);
            }
            else
            {
                throw new ArgumentException($"Scheme not supported with {scheme}.");
            }
        }
    }
}