using GregoryJenk.Mastermind.Message.ViewModels.Users;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Twitter;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users
{
    /// <summary>
    /// This service client does not need to inherit from base service client as it is read only from an external source.
    /// </summary>
    public class TwitterUserServiceClient : IExternalUserServiceClient
    {
        public TwitterUserServiceClient(IOptions<TwitterServiceOption> twitterServiceOption)
        {
            throw new NotImplementedException();
        }

        public Uri ReadAuthoriseUri()
        {
            throw new NotImplementedException();
        }

        public UserViewModel ReadByCode(string code)
        {
            throw new NotImplementedException();
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
    }
}