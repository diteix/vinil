using System.Threading.Tasks;
using Vinil.Contracts.Common;
using Vinil.Contracts.Sales.Filters;
using Vinil.Contracts.Sales.Models;

namespace Vinil.Contracts.Sales
{
    public interface ISalesApplication : IApplication<ISalesModel, int, ISalesFilter>
    {
        Task<ISalesModel> RegisterSaleAsync(IRegisterSaleModel sale);
    }
}
