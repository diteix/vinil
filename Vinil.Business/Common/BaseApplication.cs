using System.Linq;
using Vinil.Contracts.Common.Filters;

namespace Vinil.Business.Common
{
    public abstract class BaseApplication
    {
        protected IQueryable<T> Limit<T, TKey>(IQueryable<T> collection, IBaseFilter filter)
        {
            return collection.Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize);
        }
    }
}
