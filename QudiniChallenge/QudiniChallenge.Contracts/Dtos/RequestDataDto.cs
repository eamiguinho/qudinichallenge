using Newtonsoft.Json;

namespace QudiniChallenge.Contracts.Dtos
{
    public class RequestDataDto    
    {
        [JsonProperty(PropertyName = "queueData")]
        public QueueDataDto QueueData { get; set; }
            
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
