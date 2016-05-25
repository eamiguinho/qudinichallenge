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
