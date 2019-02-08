using Newtonsoft.Json;

namespace Vinil.CrossCutting.Http.Models
{
    public class AlbumModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
