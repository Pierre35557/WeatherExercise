using Newtonsoft.Json;

namespace WeatherForcast.Domain
{
    // todo: The idea behind the domain is to have a layer which represents business objects.
    // classes here need to be free from EF and JSON annotations, classes with annotations move into 
    // the data layer since they represent a contract with a DB or API.
    // You will often have overlap between the domain and data layer classes, this is where automapper is quite handy.
    // Additionally, domain classes should contain methods to work on the data.
    // E.g instead of writing methods in a use case to validate Coordination you could up a method here 
    // to do the validation. Basically, keep the data menthods that operation on the data together.
    public class Coordination
    {
        [JsonProperty("lon")]
        public float Longitude { get; set; }

        [JsonProperty("lat")]
        public float Latitude { get; set; }
    }
}
