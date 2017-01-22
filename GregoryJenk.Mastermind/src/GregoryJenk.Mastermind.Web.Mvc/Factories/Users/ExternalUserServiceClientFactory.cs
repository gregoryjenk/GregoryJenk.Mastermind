using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Google;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Twitter;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Factories.Users
{
    public class ExternalUserServiceClientFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ExternalUserServiceClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IExternalUserServiceClient Create(string scheme)
        {
            switch (scheme.ToLower())
            {
                case "google":
                    //Not ideal to have this service locator type approach, another way is to inject the options into the factory.
                    IOptions<GoogleServiceOption> googleServiceOption = (IOptions<GoogleServiceOption>)_serviceProvider.GetService(typeof(IOptions<GoogleServiceOption>));

                    return new GoogleUserServiceClient(googleServiceOption);
                case "twitter":
                    IOptions<TwitterServiceOption> twitterServiceOption = (IOptions<TwitterServiceOption>)_serviceProvider.GetService(typeof(IOptions<TwitterServiceOption>));

                    return new TwitterUserServiceClient(twitterServiceOption);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}