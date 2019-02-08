using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinil.Business.Common.Contracts;

namespace Vinil.DAL.Common
{
    public abstract class BaseDataContext<T, TKey> : IDataContext<T, TKey>
    {
        protected static ISet<T> Entity = new HashSet<T>();

        public abstract Task<IQueryable<T>> FindAsync();

        public abstract Task<T> GetAsync(TKey id);
    }
}
