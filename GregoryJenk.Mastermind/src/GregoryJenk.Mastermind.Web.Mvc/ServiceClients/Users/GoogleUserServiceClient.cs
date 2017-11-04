using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Web.Mvc.Options.Authentication.Google;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Google;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users
{
    /// <summary>
    /// This service client does not need to inherit from base service client as it is read only from an external source.
    /// </summary>
    public class GoogleUserServiceClient : IExternalUserServiceClient
    {
        private readonly IOptions<GoogleAuthenticationOption> _googleAuthenticationOption;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _resource;

        public GoogleUserServiceClient(IOptions<GoogleAuthenticationOption> googleAuthenticationOption, IOptions<GoogleServiceOption> googleServiceOption)
        {
            _googleAuthenticationOption = googleAuthenticationOption;

            _httpClient = new HttpClient()
            {
                BaseAddress = googleServiceOption.Value.BaseUrl
            };

            _apiKey = googleServiceOption.Value.ApiKey;

            _resource = "plus";
        }

        public Uri ReadAuthoriseUri()
        {
            IAuthorizationCodeFlow authorizationCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer()
            {
                ClientSecrets = new ClientSecrets()
                {
                    ClientId = _googleAuthenticationOption.Value.ClientId,
                    ClientSecret = _googleAuthenticationOption.Value.ClientSecret
                },
                Scopes = new string[]
                {
                    "https://www.googleapis.com/auth/userinfo.email"
                }
            });

            //TODO: Parameterise the redirect URI.
            Uri authorizationCodeRequestUrl = authorizationCodeFlow.CreateAuthorizationCodeRequest("http://localhost:50793/login-google").Build();

            return authorizationCodeRequestUrl;
        }

        public ExternalUserViewModel ReadById(string id)
        {
            var externalUserViewModel = new ExternalUserViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(string.Format("{0}/v1/people/{1}?key={2}", _resource, id, _apiKey)).Result;

                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {
                    dynamic json = JObject.Parse(httpResponseMessage.Content.ReadAsStringAsync().Result);

                    if (!string.IsNullOrEmpty(Convert.ToString(json.image.url)))
                    {
                        externalUserViewModel.Image = ReadImage(Convert.ToString(json.image.url));
                    }
                }
            }

            return externalUserViewModel;
        }

        public IList<ExternalUserViewModel> ReadAll()
        {
            throw new NotImplementedException();
        }

        public IList<ExternalUserViewModel> ReadAll(int index, int count)
        {
            throw new NotImplementedException();
        }

        private string ReadImage(string path)
        {
            //byte[] imageArray = System.IO.File.ReadAllBytes(path.Replace("?sz=50", ""));

            //string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return path;
        }
    }
}