using System.Collections.Generic;
using System.Threading.Tasks;
using QudiniChallenge.Contracts.Domain;
using QudiniChallenge.Global;

namespace QudiniChallenge.Contracts.DataServices
{
    public interface ICustomerQueueDataService
    {
        Task<DataResult<List<ICustomer>>> GetCustomerQueue();
    }
}