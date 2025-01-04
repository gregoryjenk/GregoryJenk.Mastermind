using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using GregoryJenk.Mastermind.Service.Strategies.Authentication;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Strategies.Authentication
{
    public class AuthenticationAuthorityGoogleStrategy : IAuthenticationAuthorityStrategy
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly Uri _redirectUrl;

        public AuthenticationAuthorityGoogleStrategy(IOptions<AuthenticationAuthorityGoogleStrategyOption> authenticationAuthorityGoogleStrategyOption)
        {
            _clientId = authenticationAuthorityGoogleStrategyOption.Value.ClientId;
            _clientSecret = authenticationAuthorityGoogleStrategyOption.Value.ClientSecret;
            _redirectUrl = authenticationAuthorityGoogleStrategyOption.Value.RedirectUrl;
        }

        public Uri ReadUrl()
        {
            var clientSecrets = new ClientSecrets()
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret
            };

            var scopes = new string[]
            {
                "https://www.googleapis.com/auth/userinfo.email",
                "https://www.googleapis.com/auth/userinfo.profile"
            };

            var initializer = new AuthorizationCodeFlow.Initializer(GoogleAuthConsts.OidcAuthorizationUrl, GoogleAuthConsts.OidcTokenUrl)
            {
                ClientSecrets = clientSecrets,
                Scopes = scopes
            };

            var authorizationCodeFlow = new AuthorizationCodeFlow(initializer);

            var authorizationCodeRequestUrl = authorizationCodeFlow.CreateAuthorizationCodeRequest(_redirectUrl.AbsoluteUri);

            return authorizationCodeRequestUrl.Build();
        }
    }
}