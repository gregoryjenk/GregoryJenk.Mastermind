using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Web.Mvc.Options.Authentication.Google;
using GregoryJenk.Mastermind.Web.Mvc.Options.Authentication.Jwt;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Google;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users
{
    /// <summary>
    /// This service client does not need to inherit from base service client as it is read only from an external source.
    /// </summary>
    public class GoogleUserServiceClient : IExternalUserServiceClient
    {
        private readonly IOptions<GoogleAuthenticationOption> _googleAuthenticationOption;
        private readonly IOptions<JwtAuthenticationOption> _jwtAuthenticationOption;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _resource;

        public GoogleUserServiceClient(IOptions<GoogleAuthenticationOption> googleAuthenticationOption, IOptions<GoogleServiceOption> googleServiceOption, IOptions<JwtAuthenticationOption> jwtAuthenticationOption)
        {
            _googleAuthenticationOption = googleAuthenticationOption;
            _jwtAuthenticationOption = jwtAuthenticationOption;

            _httpClient = new HttpClient()
            {
                BaseAddress = googleServiceOption.Value.BaseUrl
            };

            _apiKey = googleServiceOption.Value.ApiKey;

            _resource = "plus";
        }

        public Uri ReadAuthoriseUri()
        {
            IAuthorizationCodeFlow authorizationCodeFlow = CreateAuthorisationFlow();

            Uri authorizationCodeRequestUrl = authorizationCodeFlow.CreateAuthorizationCodeRequest($"{_jwtAuthenticationOption.Value.ValidAudience}login-google").Build();

            return authorizationCodeRequestUrl;
        }

        public UserViewModel ReadByCode(string code)
        {
            UserViewModel userViewModel = new UserViewModel();

            IAuthorizationCodeFlow authorizationCodeFlow = CreateAuthorisationFlow();

            CancellationToken cancellationToken = new CancellationToken();

            TokenResponse tokenResponse = authorizationCodeFlow.ExchangeCodeForTokenAsync("", code, $"{_jwtAuthenticationOption.Value.ValidAudience}login-google", cancellationToken).Result;

            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(string.Format("oauth2/v1/userinfo?alt=json&access_token={0}", tokenResponse.AccessToken)).Result;

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                dynamic json = JObject.Parse(httpResponseMessage.Content.ReadAsStringAsync().Result);

                if (!string.IsNullOrEmpty(Convert.ToString(json.name)))
                {
                    userViewModel.Name = Convert.ToString(json.name);
                }

                if (!string.IsNullOrEmpty(Convert.ToString(json.email)))
                {
                    userViewModel.Email = Convert.ToString(json.email);
                }

                if (!string.IsNullOrEmpty(Convert.ToString(json.id)))
                {
                    userViewModel.ExternalId = Convert.ToString(json.id);
                }

                if (!string.IsNullOrEmpty(Convert.ToString(json.picture)))
                {
                    userViewModel.Image = ReadImage(Convert.ToString(json.picture));
                }
            }

            return userViewModel;
        }

        public UserViewModel ReadById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<UserViewModel> ReadAll()
        {
            throw new NotImplementedException();
        }

        public IList<UserViewModel> ReadAll(int index, int count)
        {
            throw new NotImplementedException();
        }

        private IAuthorizationCodeFlow CreateAuthorisationFlow()
        {
            return new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer()
            {
                ClientSecrets = new ClientSecrets()
                {
                    ClientId = _googleAuthenticationOption.Value.ClientId,
                    ClientSecret = _googleAuthenticationOption.Value.ClientSecret
                },
                Scopes = new string[]
                {
                    "https://www.googleapis.com/auth/userinfo.email",
                    "https://www.googleapis.com/auth/userinfo.profile"
                }
            });
        }

        private string ReadImage(string path)
        {
            //byte[] imageArray = System.IO.File.ReadAllBytes(path.Replace("?sz=50", ""));

            //string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return path;
        }
    }
}