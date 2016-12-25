using GregoryJenk.Mastermind.Message.ViewModels.Users;
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
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _resource;

        public GoogleUserServiceClient(IOptions<GoogleServiceOption> googleServiceOption)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = googleServiceOption.Value.BaseUrl
            };

            _apiKey = googleServiceOption.Value.ApiKey;

            _resource = "plus";
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

                    externalUserViewModel.Image = json.image.url;
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
    }
}