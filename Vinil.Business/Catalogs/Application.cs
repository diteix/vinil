using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinil.Business.Catalogs.Contracts;
using Vinil.Business.Catalogs.Contracts.Entities;
using Vinil.Business.Catalogs.Models;
using Vinil.Business.Common;
using Vinil.Contracts.Catalogs;
using Vinil.Contracts.Catalogs.Filters;
using Vinil.Contracts.Catalogs.Models;

namespace Vinil.Business.Catalogs
{
    public class Application : BaseApplication, ICatalogsApplication
    {
        private readonly ICatalogsDataContext _dataContext;

        public Application(ICatalogsDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<ICatalogsModel>> FilterAsync(ICatalogsFilter filter)
        {
            var catalogs = await _dataContext.FindAsync();

            return Limit<ICatalog, int>(catalogs
                .Where(s => string.IsNullOrEmpty(filter.Genre) || s.Genre == filter.Genre)
                    .OrderBy(s => s.Name), filter)
                .Select(s => new CatalogsModel() { Id = s.Id, Value = s.Value, Name = s.Name, Genre = s.Genre });
        }

        public async Task<ICatalogsModel> GetAsync(int id)
        {
            var catalog = await _dataContext.GetAsync(id);

            if (catalog == null)
            {
                return null;
            }

            return new CatalogsModel()
            {
                Id = catalog.Id,
                Value = catalog.Value,
                Name = catalog.Name,
                Genre = catalog.Genre
            };
        }
    }
}
