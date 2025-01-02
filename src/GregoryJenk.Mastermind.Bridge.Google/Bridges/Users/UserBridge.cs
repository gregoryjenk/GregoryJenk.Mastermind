using AutoMapper;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using GregoryJenk.Mastermind.Bridge.Google.Responses.Users;
using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Service.Bridges.Users;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Bridge.Google.Bridges.Users
{
    public class UserBridge : IUserBridge
    {
        private readonly Uri _baseUrl;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly Uri _redirectUrl;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public UserBridge(IOptions<BridgeOption> bridgeOption, IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _baseUrl = bridgeOption.Value.BaseUrl;
            _clientId = bridgeOption.Value.ClientId;
            _clientSecret = bridgeOption.Value.ClientSecret;
            _redirectUrl = bridgeOption.Value.RedirectUrl;
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<UserViewModel> ReadByCodeAsync(string code)
        {
            var tokenResponse = await ReadTokenResponseByCodeAsync(code);

            var httpClient = _httpClientFactory.CreateClient();

            var httpRequestMessageUrl = new Uri(_baseUrl, "oauth2/v3/userinfo");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, httpRequestMessageUrl);

            httpRequestMessage.Headers.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(tokenResponse.TokenType, tokenResponse.AccessToken);

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var userInfoResponse = await httpResponseMessage.Content.ReadFromJsonAsync<UserInfoResponse>();

                return _mapper.Map<UserViewModel>(userInfoResponse);
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        private async Task<TokenResponse> ReadTokenResponseByCodeAsync(string code)
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

            return await authorizationCodeFlow.ExchangeCodeForTokenAsync(string.Empty, code, _redirectUrl.AbsoluteUri, CancellationToken.None);
        }
    }
}