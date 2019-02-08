using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinil.Business.Catalogs.Contracts;
using Vinil.Business.Catalogs.Models;
using Vinil.Business.Common;
using Vinil.Business.Sales.Contracts;
using Vinil.Business.Sales.Contracts.Entities;
using Vinil.Business.Sales.Models;
using Vinil.Contracts.Sales;
using Vinil.Contracts.Sales.Filters;
using Vinil.Contracts.Sales.Models;

namespace Vinil.Business.Sales
{
    public class Application : BaseApplication, ISalesApplication
    {
        private readonly ISalesDataContext _dataContext;
        private readonly ICatalogsDataContext _catalogsContext;

        public Application(ISalesDataContext dataContext, ICatalogsDataContext catalogsContext)
        {
            _dataContext = dataContext;
            _catalogsContext = catalogsContext;
        }

        public async Task<IEnumerable<ISalesModel>> FilterAsync(ISalesFilter filter)
        {
            var sales = await _dataContext.FindAsync();

            return Limit<ISale, int>(sales
                .Where(s => !(filter.StartDate.HasValue && filter.EndDate.HasValue) ||
                    (s.Date >= filter.StartDate && s.Date <= filter.EndDate))
                    .OrderByDescending(s => s.Date),
                filter)
                .Select(s => new SalesModel(s.Value, s.CashBack) { Id = s.Id, Date = s.Date, Items = s.Items.Select(c => new CatalogsModel() { Id = c.Id, Value = c.Value, Name = c.Name, Genre = c.Genre }) });
        }

        public async Task<ISalesModel> GetAsync(int id)
        {
            var sale = await _dataContext.GetAsync(id);

            if (sale == null)
            {
                return null;
            }

            return new SalesModel(sale.Value, sale.CashBack)
            {
                Id = sale.Id,
                Date = sale.Date,
                Items = sale.Items.Select(c => new CatalogsModel() { Id = c.Id, Value = c.Value, Name = c.Name, Genre = c.Genre })
            };
        }

        public async Task<ISalesModel> RegisterSaleAsync(IRegisterSaleModel registerSaleModel)
        {
            var catalogs = await Task.WhenAll((registerSaleModel.Items ?? Enumerable.Empty<int>()).Select(s => _catalogsContext.GetAsync(s)));

            if (!catalogs.Any() || !catalogs.All(s => s != null))
            {
                return null;
            }

            var saleModel = new SalesModel()
            {
                Date = registerSaleModel.Date,
                Items = catalogs.Select(s => new CatalogsModel() { Id = s.Id, Value = s.Value, Name = s.Name, Genre = s.Genre })
            };

            var sale = new Sale()
            {
                CashBack = saleModel.CashBack,
                Value = saleModel.Value,
                Date = saleModel.Date,
                Items = catalogs
            };

            await _dataContext.AddAsync(sale);

            saleModel.Id = sale.Id;

            return saleModel;
        }
    }
}
