using Vinil.Business.Catalogs.Contracts.Entities;

namespace Vinil.Business.Catalogs.Models
{
    public class Catalog : ICatalog
    {
        public decimal CashBack { get; set; }

        public string Genre { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}
