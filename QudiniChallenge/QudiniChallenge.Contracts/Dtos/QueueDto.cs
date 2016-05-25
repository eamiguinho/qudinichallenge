using System.Collections.Generic;
using Newtonsoft.Json;

namespace QudiniChallenge.Contracts.Dtos
{
    public class QueueDto
    {
        [JsonProperty(PropertyName = "customersToday")]
        public List<CustomersTodayDto> CustomersToday { get; set; }
    }
}