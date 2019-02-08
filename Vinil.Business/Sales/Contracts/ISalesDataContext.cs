using System.Threading.Tasks;
using Vinil.Business.Common.Contracts;
using Vinil.Business.Sales.Contracts.Entities;

namespace Vinil.Business.Sales.Contracts
{
    public interface ISalesDataContext : IDataContext<ISale, int>
    {
        Task AddAsync(ISale entity);
    }
}
