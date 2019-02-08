using System;
using System.Collections.Generic;
using Vinil.Business.Catalogs.Contracts.Entities;
using Vinil.Business.Sales.Contracts.Entities;

namespace Vinil.Business.Sales.Models
{
    public class Sale : ISale
    {
        public decimal CashBack { get; set; }

        public DateTime Date { get; set; }

        public int Id { get; set; }

        public IEnumerable<ICatalog> Items { get; set; }

        public decimal Value { get; set; }
    }
}
