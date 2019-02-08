using Vinil.Business.Catalogs.Contracts.Entities;
using Vinil.DAL.Common.Entities;

namespace Vinil.DAL.Catalogs.Entities
{
    public class Catalog : BaseEntity<int>, ICatalog
    {
        public string Name { get; set; }

        public string Genre { get; set; }
    }
}
