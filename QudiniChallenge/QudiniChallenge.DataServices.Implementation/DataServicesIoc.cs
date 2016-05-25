using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using QudiniChallenge.Contracts.DataServices;
using QudiniChallenge.Global;

namespace QudiniChallenge.DataServices.Implementation
{
    public static class DataServicesIoc
    {
        public static void Register()
        {
            Ioc.Instance.RegisterType<LoginCredentials>().As<ILoginCredentials>().SingleInstance();
            Ioc.Instance.RegisterType<CustomerQueueDataService>().As<ICustomerQueueDataService>().SingleInstance();
        }
    }
}
