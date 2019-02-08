namespace Vinil.Contracts.Common.Filters
{
    public interface IBaseFilter
    {
        int Page { get; set; }

        int PageSize { get; set; }
    }
}
