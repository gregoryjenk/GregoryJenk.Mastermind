using GregoryJenk.Mastermind.Service.Strategies.Authentication;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Web.Mvc.Handlers.Authentication
{
    public class AuthenticationHeaderHandler : DelegatingHandler
    {
        private readonly IAuthenticationStoreStrategy _authenticationStoreStrategy;

        public AuthenticationHeaderHandler(IAuthenticationStoreStrategy authenticationStoreStrategy)
        {
            _authenticationStoreStrategy = authenticationStoreStrategy;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
        {
            if (httpRequestMessage.Headers.Authorization is null)
            {
                var authenticationStoreStrategyItem = _authenticationStoreStrategy.Get();

                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(authenticationStoreStrategyItem.Scheme, authenticationStoreStrategyItem.Token);
            }

            return await base.SendAsync(httpRequestMessage, cancellationToken);
        }
    }
}