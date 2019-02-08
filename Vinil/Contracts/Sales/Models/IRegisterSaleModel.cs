using System;
using System.Collections.Generic;

namespace Vinil.Contracts.Sales.Models
{
    public interface IRegisterSaleModel
    {
        DateTime Date { get; set; }

        IEnumerable<int> Items { get; set; }
    }
}
