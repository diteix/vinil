using System;
using System.Collections.Generic;
using Vinil.Contracts.Catalogs.Models;
using Vinil.Contracts.Common.Models;

namespace Vinil.Contracts.Sales.Models
{
    public interface ISalesModel : IBaseModel<int>
    {
        IEnumerable<ICatalogsModel> Items { get; set; }

        DateTime Date { get; set; }
    }
}
