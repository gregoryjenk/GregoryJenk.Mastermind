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
            throw new NotImplementedException();
        }

        public VM ReadById(VmId id)
        {
            throw new NotImplementedException();
        }

        public IList<VM> ReadAll()
        {
            throw new NotImplementedException();
        }

        public IList<VM> ReadAll(int index, int count)
        {
            throw new NotImplementedException();
        }
    }
}