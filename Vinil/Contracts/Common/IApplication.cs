using System.Collections.Generic;
using System.Threading.Tasks;
using Vinil.Contracts.Common.Filters;

namespace Vinil.Contracts.Common
{
    public interface IApplication<T, TKey, KFilter> where KFilter : IBaseFilter
    {
        Task<IEnumerable<T>> FilterAsync(KFilter filter);

        Task<T> GetAsync(TKey id);
    }
}
