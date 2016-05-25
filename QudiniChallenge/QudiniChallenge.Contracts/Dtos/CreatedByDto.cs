using Newtonsoft.Json;

namespace QudiniChallenge.Contracts.Dtos
{
    public class CreatedByDto
    {
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}