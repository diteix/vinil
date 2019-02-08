using Vinil.Contracts.Common.Models;

namespace Vinil.Contracts.Catalogs.Models
{
    public interface ICatalogsModel : IBaseModel<int>
    {
        string Name { get; set; }

        string Genre { get; set; }

        decimal CashBackPercentage();
    }
}
