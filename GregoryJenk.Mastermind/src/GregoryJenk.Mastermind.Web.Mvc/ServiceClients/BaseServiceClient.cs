using GregoryJenk.Mastermind.Message.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients
{
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
            throw new NotImplementedException();
        }

        public void Update(VmId id, VM viewModel)
        {
            throw new NotImplementedException();
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