using Newtonsoft.Json;

namespace Vinil.CrossCutting.Http.Models
{
    public class ArtistModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
