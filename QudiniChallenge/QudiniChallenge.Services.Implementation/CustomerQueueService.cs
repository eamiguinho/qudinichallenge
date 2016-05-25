using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QudiniChallenge.Contracts.DataServices;
using QudiniChallenge.Contracts.Domain;
using QudiniChallenge.Contracts.Services;
using QudiniChallenge.Global;

namespace QudiniChallenge.Services.Implementation
{
    public class CustomerQueueService : ICustomerQueueService
    {
        private readonly ICustomerQueueDataService _dataService;

        public CustomerQueueService(ICustomerQueueDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<DataResult<List<ICustomer>>> GetCustomerQueue()
        {
            var queryDataService = await _dataService.GetCustomerQueue();
            if (queryDataService.IsOk)
            {
               var orderByExpectedTime = queryDataService.Data.OrderBy(x => x.ExpectedTime).ToList();
               return new DataResult<List<ICustomer>>(orderByExpectedTime);
            }
            return queryDataService;
        }
    }
}
