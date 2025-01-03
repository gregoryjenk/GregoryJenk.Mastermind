using GregoryJenk.Mastermind.Message.ViewModels.Users;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Threading.Tasks;

namespace GregoryJenk.Mastermind.Service.Proxies.Users
{
    public class UserProxy : IUserProxy
    {
        private readonly Uri _baseUrl;
        private readonly IHttpClientFactory _httpClientFactory;

        public UserProxy(IOptions<ProxyOption> proxyOption, IHttpClientFactory httpClientFactory)
        {
            _baseUrl = proxyOption.Value.BaseUrl;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserViewModel> ReadAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(ProxyConstant.DefaultName);

            var httpRequestMessageUrl = new Uri(_baseUrl, "user");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, httpRequestMessageUrl);

            httpRequestMessage.Headers.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<UserViewModel>();
            }
            else
            {
                //When no user is found return null to be handled by the caller.
                if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw new HttpRequestException();
            }
        }

        public async Task<UserViewModel> UpsertAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(ProxyConstant.DefaultName);

            var httpRequestMessageUrl = new Uri(_baseUrl, "user");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, httpRequestMessageUrl);

            httpRequestMessage.Headers.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<UserViewModel>();
            }
            else
            {
                throw new HttpRequestException();
            }
        }
    }
}