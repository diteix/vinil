using Newtonsoft.Json;

namespace Vinil.CrossCutting.Http.Models
{
    public class RequestModel<T>
    {
        [JsonProperty("artists")]
        public SearchModel<T> Searchs { get; set; }
    }
}
