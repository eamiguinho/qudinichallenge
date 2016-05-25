using System.Collections.Generic;
using System.Threading.Tasks;
using QudiniChallenge.Contracts.Domain;
using QudiniChallenge.Global;

namespace QudiniChallenge.Contracts.Services
{
   public interface ICustomerQueueService
    {
        Task<DataResult<List<ICustomer>>> GetCustomerQueue();
    }
}
