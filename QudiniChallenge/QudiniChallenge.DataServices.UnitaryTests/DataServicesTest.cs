using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using QudiniChallenge.Contracts.DataServices;
using QudiniChallenge.DataServices.Implementation;
using QudiniChallenge.Domain.Implementation;
using QudiniChallenge.Global;

namespace QudiniChallenge.DataServices.UnitaryTests
{
    [TestClass]
    public class DataServicesTest
    {
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            DataServicesIoc.Register();
            DomainIoc.Register();
        }

        [TestMethod]
        public async Task TestCallAPINoUserPass()
        {
            var credentials = Substitute.For<ILoginCredentials>();
            credentials.Username.Returns(null as string);
            credentials.Password.Returns(null as string);
            var dataService = new CustomerQueueDataService(credentials);
            var res = await dataService.GetCustomerQueue();
            Assert.AreEqual(Result.Error, res.Result);
        }

        [TestMethod]
        public async Task TestCallAPIBadUserPass()
        {       
            //TODO THIS WILL FAIL BECAUSE EVEN BLOCKING REDIRECTS WITH WRONG CREDENTIALS SERVER RETURNS 302, ALLOWING REDIRECTS IT RETURNS ONE HTTP PAGE 200 OK
            var credentials = Substitute.For<ILoginCredentials>();
            credentials.Username.Returns("test1");
            credentials.Password.Returns("test2");
            var dataService = new CustomerQueueDataService(credentials);
            var res = await dataService.GetCustomerQueue();
            Assert.AreEqual(Result.InvalidCredentials, res.Result);
        }

        [TestMethod]
        public async Task TestCallAPICorrectUserPass()
        {
            var credentials = Substitute.For<ILoginCredentials>();
            credentials.Username.Returns("codetest1");
            credentials.Password.Returns("codetest100");
            var dataService = new CustomerQueueDataService(credentials);
            var res = await dataService.GetCustomerQueue();
            Assert.AreEqual(Result.Ok, res.Result);
        }
    }
}
