using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using QudiniChallenge.Contracts.DataServices;
using QudiniChallenge.Contracts.Services;
using QudiniChallenge.Global;

namespace QudiniChallenge.Services.Implementation
{
    public static class ServicesIoc 
    {
        public static void Register()
        {
            Ioc.Instance.RegisterType<CustomerQueueService>().As<ICustomerQueueService>().SingleInstance();
        }
    }
}
