using GregoryJenk.Mastermind.Message.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients
{
    //TODO: Consider using the async return values.
    public abstract class BaseServiceClient<VM, VmId> where VM : BaseViewModel<VmId>
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _resource;

        public BaseServiceClient(Uri baseUrl, string resource)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = baseUrl
            };

            _resource = resource;
        }

        public VmId Create(VM viewModel)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync(_resource,
                new ObjectContent<VM>(viewModel, new JsonMediaTypeFormatter())).Result;

            httpResponseMessage.EnsureSuccessStatusCode();

            return (VmId)(object)httpResponseMessage.Headers.Location.Segments.Last();
        }

        public void Update(VmId id, VM viewModel)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync(string.Format("{0}/{1}", _resource, id),
                new ObjectContent<VM>(viewModel, new JsonMediaTypeFormatter())).Result;

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public void Delete(VmId id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync(string.Format("{0}/{1}", _resource, id)).Result;

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public VM ReadById(VmId id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(string.Format("{0}/{1}", _resource, id)).Result;

            httpResponseMessage.EnsureSuccessStatusCode();

            return httpResponseMessage.Content.ReadAsAsync<VM>().Result;
        }

        public IList<VM> ReadAll()
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(_resource).Result;

            httpResponseMessage.EnsureSuccessStatusCode();

            return httpResponseMessage.Content.ReadAsAsync<IList<VM>>().Result;
        }

        public IList<VM> ReadAll(int index, int count)
        {
            throw new NotImplementedException();
        }
    }
}