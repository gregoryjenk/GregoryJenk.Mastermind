using GregoryJenk.Mastermind.Message.Requests.Games;
using GregoryJenk.Mastermind.Message.ViewModels.Games;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Service.Proxies.Games
{
    public class GameProxy : IGameProxy
    {
        private readonly Uri _baseUrl;
        private readonly IHttpClientFactory _httpClientFactory;

        public GameProxy(IOptions<ProxyOption> proxyOption, IHttpClientFactory httpClientFactory)
        {
            _baseUrl = proxyOption.Value.BaseUrl;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GameViewModel> ReadByIdAsync(Guid id)
        {
            var httpClient = _httpClientFactory.CreateClient(ProxyConstant.DefaultName);

            var httpRequestMessageUrl = new Uri(_baseUrl, $"game/{id}");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, httpRequestMessageUrl);

            httpRequestMessage.Headers.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<GameViewModel>();
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        public async Task<GameViewModel> CreateAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(ProxyConstant.DefaultName);

            var httpRequestMessageUrl = new Uri(_baseUrl, "game");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, httpRequestMessageUrl);

            httpRequestMessage.Headers.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<GameViewModel>();
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        public async Task<IList<GameViewModel>> ReadByDecoderUserIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GameViewModel> CreateGuessAsync(GameCreateGuessRequest gameCreateGuessRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<GameViewModel> UpdateStateAsync(GameUpdateStateRequest gameUpdateStateRequest)
        {
            throw new NotImplementedException();
        }
    }
}