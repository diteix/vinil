using System;
using System.Collections.Generic;
using Vinil.Business.Catalogs.Contracts.Entities;
using Vinil.Business.Sales.Contracts.Entities;
using Vinil.DAL.Common.Entities;

namespace Vinil.DAL.Sales.Entities
{
    public class Sale : BaseEntity<int>, ISale
    {
        public IEnumerable<ICatalog> Items { get; set; }

        public DateTime Date { get; set; }
    }
}
