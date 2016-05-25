using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QudiniChallenge.Contracts.DataServices;
using QudiniChallenge.Contracts.Domain;
using QudiniChallenge.Contracts.PlatformSpecific;
using QudiniChallenge.Contracts.Services;
using QudiniChallenge.Global;

namespace QudiniChallenge.Services.Implementation
{
    public class CustomerQueueService : ICustomerQueueService
    {
        private readonly ICustomerQueueDataService _dataService;
        private readonly IPlatformSpecificService _platformSpecificService;

        public CustomerQueueService(ICustomerQueueDataService dataService, IPlatformSpecificService platformSpecificService)
        {
            _dataService = dataService;
            _platformSpecificService = platformSpecificService;
        }

        public async Task<DataResult<List<ICustomer>>> GetCustomerQueue()
        {
            if (!_platformSpecificService.HasInternetConnection())
                return new DataResult<List<ICustomer>>(Result.NoInternetConnection);
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
