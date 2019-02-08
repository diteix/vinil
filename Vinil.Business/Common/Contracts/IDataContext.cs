using System.Linq;
using System.Threading.Tasks;

namespace Vinil.Business.Common.Contracts
{
    public interface IDataContext<T, TKey>
    {
        Task<IQueryable<T>> FindAsync();

        Task<T> GetAsync(TKey id);
    }
}
