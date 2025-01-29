using AutoMapper;
using GregoryJenk.Mastermind.Bridge.Google.Bridges;
using GregoryJenk.Mastermind.Bridge.Google.Bridges.Users;
using GregoryJenk.Mastermind.Service.Bridges.Users;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Http;

namespace GregoryJenk.Mastermind.Web.Mvc.Factories.Users
{
    public class UserBridgeFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public UserBridgeFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUserBridge Create(string scheme)
        {
            switch (scheme)
            {
                case FactoryConstant.GoogleScheme:
                {
                    //Not ideal to have this service locator type approach, another way is to inject the dependencies into the factory.
                    var bridgeOption = _serviceProvider.GetService(typeof(IOptions<BridgeOption>)) as IOptions<BridgeOption>;
                    var httpClientFactory = _serviceProvider.GetService(typeof(IHttpClientFactory)) as IHttpClientFactory;
                    var mapper = _serviceProvider.GetService(typeof(IMapper)) as IMapper;

                    return new UserBridge(bridgeOption, httpClientFactory, mapper);
                }
                default:
                {
                    throw new ArgumentException($"Scheme not supported with {scheme}.");
                }
            }
        }
    }
}