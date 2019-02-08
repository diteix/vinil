using System;
using System.Collections.Generic;
using Vinil.Contracts.Sales.Models;

namespace Vinil.Models
{
    public class SalesModel : IRegisterSaleModel
    {
        public DateTime Date { get; set; }

        public IEnumerable<int> Items { get; set; }
    }
}