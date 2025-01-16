using GregoryJenk.Mastermind.Web.Mvc.Factories.Authentication;
using GregoryJenk.Mastermind.Web.Mvc.Strategies.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Test.Factories.Authentication
{
    [TestClass, TestCategory("Unit")]
    public class AuthenticationAuthorityStrategyFactoryTest
    {
        [TestMethod]
        public void Create_WithGoogle_ReturnAuthenticationAuthorityGoogleStrategy()
        {
            var authenticationAuthorityGoogleStrategyOptionMock = new Mock<IOptions<AuthenticationAuthorityGoogleStrategyOption>>();

            authenticationAuthorityGoogleStrategyOptionMock.Setup(authenticationAuthorityGoogleStrategyOption => authenticationAuthorityGoogleStrategyOption.Value)
                .Returns(new AuthenticationAuthorityGoogleStrategyOption());

            var serviceProviderMock = new Mock<IServiceProvider>();

            serviceProviderMock.Setup(serviceProvider => serviceProvider.GetService(typeof(IOptions<AuthenticationAuthorityGoogleStrategyOption>)))
                .Returns(authenticationAuthorityGoogleStrategyOptionMock.Object);

            var authenticationAuthorityStrategyFactory = new AuthenticationAuthorityStrategyFactory(serviceProviderMock.Object);

            var authenticationAuthorityStrategy = authenticationAuthorityStrategyFactory.Create("google");

            Assert.IsInstanceOfType<AuthenticationAuthorityGoogleStrategy>(authenticationAuthorityStrategy);
        }
    }
}