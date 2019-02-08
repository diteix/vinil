using Vinil.Contracts.Common.Filters;

namespace Vinil.Contracts.Catalogs.Filters
{
    public interface ICatalogsFilter : IBaseFilter
    {
        string Name { get; set; }

        string Genre { get; set; }
    }
}
