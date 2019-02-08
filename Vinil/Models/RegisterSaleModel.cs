using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vinil.Models
{
    public class RegisterSaleModel
    {
        [Required]
        public IEnumerable<int> CatalogIds { get; set; }
    }
}