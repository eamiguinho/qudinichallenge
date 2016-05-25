using Newtonsoft.Json;

namespace QudiniChallenge.Contracts.Dtos
{
    public class CustomerDto
    {
        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
     
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
      
        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }
    }
}