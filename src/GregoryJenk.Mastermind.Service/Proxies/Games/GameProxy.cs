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
using System.Text;
using System.Text.Json;
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

            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, httpRequestMessageUrl))
            {
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
        }

        public async Task<GameViewModel> CreateAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(ProxyConstant.DefaultName);

            var httpRequestMessageUrl = new Uri(_baseUrl, "game");

            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, httpRequestMessageUrl))
            {
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
        }

        public async Task<IList<GameViewModel>> ReadByDecoderUserIdAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(ProxyConstant.DefaultName);

            var httpRequestMessageUrl = new Uri(_baseUrl, "game");

            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, httpRequestMessageUrl))
            {
                httpRequestMessage.Headers.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);

                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return await httpResponseMessage.Content.ReadFromJsonAsync<IList<GameViewModel>>();
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }

        public async Task<GameViewModel> CreateGuessAsync(GameCreateGuessRequest gameCreateGuessRequest)
        {
            var httpClient = _httpClientFactory.CreateClient(ProxyConstant.DefaultName);

            var httpRequestMessageUrl = new Uri(_baseUrl, $"game/{gameCreateGuessRequest.Id}/guess");

            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, httpRequestMessageUrl))
            {
                httpRequestMessage.Headers.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);

                var httpRequestMessageJson = JsonSerializer.Serialize(gameCreateGuessRequest);

                httpRequestMessage.Content = new StringContent(httpRequestMessageJson, Encoding.UTF8, MediaTypeNames.Application.Json);

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
        }

        public async Task<GameViewModel> UpdateStateAsync(GameUpdateStateRequest gameUpdateStateRequest)
        {
            var httpClient = _httpClientFactory.CreateClient(ProxyConstant.DefaultName);

            var httpRequestMessageUrl = new Uri(_baseUrl, $"game/{gameUpdateStateRequest.Id}/state");

            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, httpRequestMessageUrl))
            {
                httpRequestMessage.Headers.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);

                var httpRequestMessageJson = JsonSerializer.Serialize(gameUpdateStateRequest);

                httpRequestMessage.Content = new StringContent(httpRequestMessageJson, Encoding.UTF8, MediaTypeNames.Application.Json);

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
        }
    }
}