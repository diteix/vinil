using Vinil.Business.Catalogs.Contracts.Entities;
using Vinil.Business.Common.Contracts;

namespace Vinil.Business.Catalogs.Contracts
{
    public interface ICatalogsDataContext : IDataContext<ICatalog, int>
    {
    }
}
