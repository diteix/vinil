using Vinil.Contracts.Catalogs.Filters;
using Vinil.Contracts.Catalogs.Models;
using Vinil.Contracts.Common;

namespace Vinil.Contracts.Catalogs
{
    public interface ICatalogsApplication : IApplication<ICatalogsModel, int, ICatalogsFilter>
    {

    }
}
