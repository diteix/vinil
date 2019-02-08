using Newtonsoft.Json;
using System.Collections.Generic;

namespace Vinil.CrossCutting.Http.Models
{
    public class SearchModel<T>
    {
        [JsonProperty("items")]
        public IEnumerable<T> Items { get; set; }
    }
}
