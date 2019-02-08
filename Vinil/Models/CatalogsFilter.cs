using Vinil.Contracts.Catalogs.Filters;

namespace Vinil.Models
{
    public class CatalogsFilter : BaseFilter, ICatalogsFilter
    {
        public string Name { get; set; }

        public string Genre { get; set; }
    }
}