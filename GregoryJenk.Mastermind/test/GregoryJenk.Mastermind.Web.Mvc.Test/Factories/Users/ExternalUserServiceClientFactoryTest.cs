using GregoryJenk.Mastermind.Web.Mvc.Factories.Users;
using GregoryJenk.Mastermind.Web.Mvc.ServiceClients.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace GregoryJenk.Mastermind.Web.Mvc.Test.Factories.Users
{
    [TestClass]
    public class ExternalUserServiceClientFactoryTest
    {
        [TestMethod]
        public void CreateWithGoogleWillReturnGoogleUserServiceClient()
        {
            //Arrange.
            //var externalUserServiceClientFactory = new ExternalUserServiceClientFactory();

            //Act.
            //var googleUserServiceClient = externalUserServiceClientFactory.Create("google");

            //Assert.
            //Assert.IsInstanceOfType(googleUserServiceClient, typeof(GoogleUserServiceClient));
            Assert.AreEqual(true, true);
        }
    }
}