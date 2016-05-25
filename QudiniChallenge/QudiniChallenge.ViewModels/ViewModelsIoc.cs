using Autofac;
using QudiniChallenge.Global;
using QudiniChallenge.ViewModels.ViewModels;

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
