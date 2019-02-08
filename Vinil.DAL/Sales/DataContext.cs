using System.Linq;
using System.Threading.Tasks;
using Vinil.Business.Sales.Contracts;
using Vinil.Business.Sales.Contracts.Entities;
using Vinil.DAL.Common;

namespace Vinil.DAL.Sales
{
    public class DataContext : BaseDataContext<ISale, int>, ISalesDataContext
    {
        public async Task AddAsync(ISale entity)
        {
            entity.Id = Entity.Count + 1;

            await Task.Run(() => Entity.Add(entity));
        }

        public override async Task<IQueryable<ISale>> FindAsync()
        {
            return (await Task.Run(() => Entity)).AsQueryable();
        }

        public override async Task<ISale> GetAsync(int id)
        {
            return (await Task.Run(() => Entity)).FirstOrDefault(s => s.Id == id);
        }
    }
}
