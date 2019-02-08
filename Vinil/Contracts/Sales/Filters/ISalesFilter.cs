using System;
using Vinil.Contracts.Common.Filters;

namespace Vinil.Contracts.Sales.Filters
{
    public interface ISalesFilter : IBaseFilter
    {
        DateTime? StartDate { get; set; }

        DateTime? EndDate { get; set; }
    }
}
