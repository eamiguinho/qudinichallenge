using Autofac;
using QudiniChallenge.Contracts.Domain;
using QudiniChallenge.Global;

namespace QudiniChallenge.Domain.Implementation
{
    public static class DomainIoc
    {
        public static void Register()
        {
            Ioc.Instance.RegisterType<Customer>().As<ICustomer>();
        }
    }
}
