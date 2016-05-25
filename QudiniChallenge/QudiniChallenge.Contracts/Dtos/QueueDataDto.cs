using Newtonsoft.Json;

namespace QudiniChallenge.Contracts.Dtos
{
    public class QueueDataDto
    {
        [JsonProperty(PropertyName = "queue")]
        public QueueDto Queue { get; set; }
    }
}