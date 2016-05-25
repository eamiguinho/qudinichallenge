using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using QudiniChallenge.Contracts.DataServices;
using QudiniChallenge.Contracts.Domain;
using QudiniChallenge.Contracts.PlatformSpecific;
using QudiniChallenge.DataServices.Implementation;
using QudiniChallenge.Domain.Implementation;
using QudiniChallenge.Global;
using QudiniChallenge.Services.Implementation;

namespace QudiniChallenge.Services.UnitaryTests
{
    [TestClass]
    public class ServicesTest
    {
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            DataServicesIoc.Register();
            ServicesIoc.Register();
            DomainIoc.Register();
        }
        [TestMethod]
        public async Task ServicesTestErrorNoInternetOnDevice()
        {
            var dataService = Substitute.For<ICustomerQueueDataService>();
            dataService.GetCustomerQueue().Returns(new DataResult<List<ICustomer>>(Result.Error));
            var platformSpecific = Substitute.For<IPlatformSpecificService>();
            platformSpecific.HasInternetConnection().Returns(false);
            var service = new CustomerQueueService(dataService, platformSpecific);
            var res = await service.GetCustomerQueue();
            Assert.AreEqual(Result.NoInternetConnection, res.Result);
        }

        [TestMethod]
        public async Task ServicesTestErrorDataService()
        {
            var errormessage = "test error message";
            var dataService = Substitute.For<ICustomerQueueDataService>();
            dataService.GetCustomerQueue().Returns(new DataResult<List<ICustomer>>(Result.Error, errormessage));
            var platformSpecific = Substitute.For<IPlatformSpecificService>();
            platformSpecific.HasInternetConnection().Returns(true);
            var service = new CustomerQueueService(dataService, platformSpecific);
            var res = await service.GetCustomerQueue();
            Assert.AreEqual(Result.Error, res.Result);
            Assert.AreEqual(errormessage, res.ErrorMessage);
        }

        [TestMethod]
        public async Task ServicesTestSucessButEmptyDataService()
        {
            var dataService = Substitute.For<ICustomerQueueDataService>();
            dataService.GetCustomerQueue().Returns(new DataResult<List<ICustomer>>(new List<ICustomer>()));
            var platformSpecific = Substitute.For<IPlatformSpecificService>();
            platformSpecific.HasInternetConnection().Returns(true);
            var service = new CustomerQueueService(dataService, platformSpecific);
            var res = await service.GetCustomerQueue();
            Assert.AreEqual(Result.Ok, res.Result);
            Assert.IsTrue(res.Data.Count == 0);
        }


        [TestMethod]
        public async Task ServicesTestSucessNotEmptyDataService()
        {
            var customer1 = Ioc.Container.Resolve<ICustomer>();
            customer1.Name = "Emanuel";
            customer1.Surname = "Amiguinho";
            customer1.Email = "emanuelamiguinho@outlook.com";
            customer1.ExpectedTime = DateTime.Now.AddHours(10);


            var customer2 = Ioc.Container.Resolve<ICustomer>();
            customer2.Name = "Benoit";
            customer2.Surname = "Pasquier";
            customer2.Email = "benoit@qudini.com";
            customer2.ExpectedTime = DateTime.Now.AddHours(8);

            var listCustomer = new List<ICustomer>();
            listCustomer.Add(customer1);
            listCustomer.Add(customer2);

            var dataService = Substitute.For<ICustomerQueueDataService>();
            dataService.GetCustomerQueue().Returns(new DataResult<List<ICustomer>>(listCustomer));

            var platformSpecific = Substitute.For<IPlatformSpecificService>();
            platformSpecific.HasInternetConnection().Returns(true);
            var service = new CustomerQueueService(dataService,platformSpecific);
            var res = await service.GetCustomerQueue();
            Assert.AreEqual(Result.Ok, res.Result);
            Assert.IsTrue(res.Data.Count != 0);

            //TO PROVE THAT IS ORDERING BY EXPECTED DATE
            Assert.IsTrue(res.Data.First().Name == "Benoit");
        }
    }
}
