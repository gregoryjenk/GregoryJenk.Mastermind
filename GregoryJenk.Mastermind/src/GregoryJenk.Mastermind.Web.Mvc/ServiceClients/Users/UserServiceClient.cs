using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Games;
using GregoryJenk.Mastermind.Web.Mvc.Services.Tokens;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users
{
    public class UserServiceClient : BaseServiceClient<UserViewModel, string>, IUserServiceClient
    {
        public UserServiceClient(ITokenService tokenService, IOptions<GameServiceOption> gameServiceOption)
            : base(tokenService, gameServiceOption.Value.BaseUrl, "user")
        {

        }

        public UserViewModel Upsert()
        {
            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync(_resource, null).Result;

            httpResponseMessage.EnsureSuccessStatusCode();

            string responseJson = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<UserViewModel>(responseJson);
        }
    }
}