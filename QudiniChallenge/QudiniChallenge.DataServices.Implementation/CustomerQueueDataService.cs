using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QudiniChallenge.Contracts.DataServices;
using QudiniChallenge.Contracts.Domain;
using QudiniChallenge.Contracts.Dtos;
using QudiniChallenge.Global;

namespace QudiniChallenge.DataServices.Implementation
{   
    public class CustomerQueueDataService : ICustomerQueueDataService
    {
        private readonly ILoginCredentials _credentials;

        public CustomerQueueDataService(ILoginCredentials credentials)
        {
            _credentials = credentials;
        }

        public async Task<DataResult<List<ICustomer>>> GetCustomerQueue()
        {
            try
            {
                var url = "https://app.qudini.com/api/queue/gj9fs";
                DataResult<RequestDataDto> res = await DataServiceHelper.DoGetWithAuth<RequestDataDto>(url, _credentials);
                if (res.IsOk)
                {
                    return new DataResult<List<ICustomer>>(RequestDataDtoFactory.Create(res.Data));
                }
                return new DataResult<List<ICustomer>>(res.Result, res.ErrorMessage);
            }
            catch (Exception e)
            {
                return new DataResult<List<ICustomer>>(Result.Error, e.Message);
            }
        }   
    }
}
