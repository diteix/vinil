using System;
using Vinil.Contracts.Sales.Filters;

namespace Vinil.Models
{
    public class SalesFilter : BaseFilter, ISalesFilter
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}