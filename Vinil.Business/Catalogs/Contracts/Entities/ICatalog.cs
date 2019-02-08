using Vinil.Business.Common.Contracts.Entities;

namespace Vinil.Business.Catalogs.Contracts.Entities
{
    public interface ICatalog : IBaseEntity<int>
    {
        string Name { get; set; }

        string Genre { get; set; }
    }
}
