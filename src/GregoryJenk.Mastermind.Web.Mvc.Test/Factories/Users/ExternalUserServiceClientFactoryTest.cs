using GregoryJenk.Mastermind.Web.Mvc.Factories.Users;
using GregoryJenk.Mastermind.Web.Mvc.Options.Services.Google;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Test.Factories.Users
{
    [TestClass, TestCategory("Unit")]
    public class ExternalUserServiceClientFactoryTest
    {
        [TestMethod]
        public void CreateWithGoogleWillReturnGoogleUserServiceClient()
        {
            //Arrange.
            var googleServiceOptionMock = new Mock<IOptions<GoogleServiceOption>>();

            googleServiceOptionMock.Setup(x => x.Value).Returns(new GoogleServiceOption()
            {
                BaseUrl = new Uri("http://foo.bar")
            });

            var serviceProviderMock = new Mock<IServiceProvider>();

            serviceProviderMock.Setup(x => x.GetService(typeof(IOptions<GoogleServiceOption>))).Returns(googleServiceOptionMock.Object);

            var externalUserServiceClientFactory = new ExternalUserServiceClientFactory(serviceProviderMock.Object);

            //Act.
            var googleUserServiceClient = externalUserServiceClientFactory.Create("google");

            //Assert.
            Assert.IsInstanceOfType(googleUserServiceClient, typeof(GoogleUserServiceClient));
        }
    }
}