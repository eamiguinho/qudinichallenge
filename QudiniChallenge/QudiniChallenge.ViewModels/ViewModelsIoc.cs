using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using QudiniChallenge.Global;

namespace QudiniChallenge.ViewModels
{
    public class ViewModelsIoc
    {
        public static void Register()
        {
            Ioc.Instance.RegisterType<CustomerQueueViewModel>();
        }
    }
}
