using GregoryJenk.Mastermind.Message.Messages.Games;
using GregoryJenk.Mastermind.Message.ViewModels.Games;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Games;
using GregoryJenk.Mastermind.Web.Mvc.Services.Tokens;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Games
{
    public class GameServiceClient : BaseServiceClient<GameViewModel, Guid>, IGameServiceClient
    {
        public GameServiceClient(ITokenService tokenService, IOptions<GameServiceOption> gameServiceOption)
            : base(tokenService, gameServiceOption.Value.BaseUrl, "game")
        {
            
        }

        public GameViewModel CreateGuess(Guid id, GameViewModel gameViewModel, GuessViewModel guessViewModel)
        {
            string requestJson = JsonConvert.SerializeObject(new CreateGuessRequest() { Game = gameViewModel, Guess = guessViewModel });

            StringContent requestJsonStringContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync(string.Format("{0}/{1}/guess", _resource, id), requestJsonStringContent).Result;

            httpResponseMessage.EnsureSuccessStatusCode();

            string responseJson = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<GameViewModel>(responseJson);
        }

        public GameViewModel UpdateState(Guid id, GameViewModel gameViewModel)
        {
            string requestJson = JsonConvert.SerializeObject(gameViewModel);

            StringContent requestJsonStringContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync(string.Format("{0}/{1}/state", _resource, id), requestJsonStringContent).Result;

            httpResponseMessage.EnsureSuccessStatusCode();

            string responseJson = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<GameViewModel>(responseJson);
        }
    }
}