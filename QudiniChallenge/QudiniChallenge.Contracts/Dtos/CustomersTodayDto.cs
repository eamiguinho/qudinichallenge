using System;
using Newtonsoft.Json;

namespace QudiniChallenge.Contracts.Dtos
{
    public class CustomersTodayDto
    {
        [JsonProperty(PropertyName = "customer")]
        public CustomerDto Customer { get; set; }

        [JsonProperty(PropertyName = "expectedTime")]
        public DateTime ExpectedTime { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "originalExpectedTime")]
        public DateTime OriginalExpectedTime { get; set; }
    }
}