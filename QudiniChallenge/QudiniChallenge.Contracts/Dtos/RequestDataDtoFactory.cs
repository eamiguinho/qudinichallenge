using System.Collections.Generic;
using Autofac;
using QudiniChallenge.Contracts.Domain;
using QudiniChallenge.Global;

namespace QudiniChallenge.Contracts.Dtos
{
    public static class RequestDataDtoFactory
    {
        public static List<ICustomer> Create(RequestDataDto requestDataDto)
        {
            if (requestDataDto == null) return null;
            var listCustomers = new List<ICustomer>();
            foreach (var customerDto in requestDataDto.QueueData.Queue.CustomersToday)
            {
                var customer = Ioc.Container.Resolve<ICustomer>();
                customer.Email = customerDto.Customer.EmailAddress;
                customer.ExpectedTime = customerDto.ExpectedTime;
                customer.Name = customerDto.Customer.Name;
                customer.Surname = customerDto.Customer.Surname;
                customer.Id = customerDto.Id;
                listCustomers.Add(customer);
            }
            return listCustomers;
        }
    }
}