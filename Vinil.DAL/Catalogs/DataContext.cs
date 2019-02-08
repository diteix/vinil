using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinil.Business.Catalogs.Contracts;
using Vinil.Business.Catalogs.Contracts.Entities;
using Vinil.CrossCutting.Http;
using Vinil.DAL.Catalogs.Entities;
using Vinil.DAL.Common;

namespace Vinil.DAL.Catalogs
{
    public class DataContext : BaseDataContext<ICatalog, int>, ICatalogsDataContext
    {
        public override async Task<IQueryable<ICatalog>> FindAsync()
        {
            return (await FechDataAsync() ?? Entity).AsQueryable();
        }

        public override async Task<ICatalog> GetAsync(int id)
        {
            return (await Task.Run(() => Entity)).FirstOrDefault(s => s.Id == id);
        }

        private async Task<ISet<ICatalog>> FechDataAsync()
        {
            if (Entity.Count != 0)
            {
                return await Task.FromResult<ISet<ICatalog>>(null);
            }

            var data = await RequestClient.FetchData();

            var valueRandomizer = new Random();

            var i = 0;

            foreach (var genre in data)
            {
                for (; i < genre.Value.Count(); i++)
                {
                    Entity.Add(new Catalog()
                    {
                        Id = i + 1,
                        Genre = genre.Key,
                        Name = genre.Value.ElementAt(i),
                        Value = 1.99M * valueRandomizer.Next(30, 60)
                    });
                }
            }

            return await Task.Run(() => Entity);
        }
    }
}
