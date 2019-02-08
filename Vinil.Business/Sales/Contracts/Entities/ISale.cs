using System;
using System.Collections.Generic;
using Vinil.Business.Catalogs.Contracts.Entities;
using Vinil.Business.Common.Contracts.Entities;

namespace Vinil.Business.Sales.Contracts.Entities
{
    public interface ISale : IBaseEntity<int>
    {
        IEnumerable<ICatalog> Items { get; set; }

        DateTime Date { get; set; }
    }
}
