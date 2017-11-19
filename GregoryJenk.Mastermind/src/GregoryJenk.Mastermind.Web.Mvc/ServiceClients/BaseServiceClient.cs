using GregoryJenk.Mastermind.Message.ViewModels;
using GregoryJenk.Mastermind.Web.Mvc.Services.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients
{
    //TODO: Consider using the async return values.
    public abstract class BaseServiceClient<VM, VmId> where VM : BaseEntityViewModel<VmId>
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _resource;

        public BaseServiceClient(ITokenService tokenService, Uri baseUrl, string resource)
        {
            string tokenScheme = tokenService.ReadScheme();
            string tokenValue = tokenService.ReadValue();

            _httpClient = new HttpClient()
            {
                BaseAddress = baseUrl
            };

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenScheme, tokenValue);

            _resource = resource;
        }

        public VmId Create(VM viewModel)
        {
            string json = JsonConvert.SerializeObject(viewModel);

            StringContent jsonStringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync(_resource, jsonStringContent).Result;

            httpResponseMessage.EnsureSuccessStatusCode();

            string id = httpResponseMessage.Headers.Location.Segments.Last();

            return ConvertLocationIdToViewModelId(id);
        }

        public void Update(VmId id, VM viewModel)
        {
            string json = JsonConvert.SerializeObject(viewModel);

            StringContent jsonStringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync(string.Format("{0}/{1}", _resource, id), jsonStringContent).Result;

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public void Delete(VmId id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync(string.Format("{0}/{1}", _resource, id)).Result;

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public VM ReadById(VmId id)
        {
            //HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(string.Format("{0}/{1}", _resource, id)).Result;
            //httpResponseMessage.EnsureSuccessStatusCode();
            //return httpResponseMessage.Content.ReadAsAsync<VM>().Result;

            string json = _httpClient.GetStringAsync(string.Format("{0}/{1}", _resource, id)).Result;

            return JsonConvert.DeserializeObject<VM>(json);
        }

        public IList<VM> ReadAll()
        {
            //TODO: Check the.NET Core implementation for deserialising objects - seems broken.
            //HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(_resource).Result;
            //httpResponseMessage.EnsureSuccessStatusCode();
            //return httpResponseMessage.Content.ReadAsAsync<IList<VM>>().Result;

            //The recommended way has issues with deserialising the DateTimeOffset properties.
            //System.Runtime.Serialization.Json.DataContractJsonSerializer dataContractJsonSerializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(IList<VM>));
            //System.IO.Stream stream = _httpClient.GetStreamAsync(_resource).Result;
            //return dataContractJsonSerializer.ReadObject(stream) as IList<VM>;

            //Having to convert the response body to a string, then deserialise it to the object.
            string json = _httpClient.GetStringAsync(_resource).Result;

            return JsonConvert.DeserializeObject<IList<VM>>(json);
        }

        public IList<VM> ReadAll(int index, int count)
        {
            throw new NotImplementedException();
        }

        private VmId ConvertLocationIdToViewModelId(string id)
        {
            return (VmId)TypeDescriptor.GetConverter(typeof(VmId)).ConvertFromInvariantString(id);
        }
    }
}