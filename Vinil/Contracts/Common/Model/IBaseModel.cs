namespace Vinil.Contracts.Common.Models
{
    public interface IBaseModel<TKey>
    {
        TKey Id { get; set; }

        decimal Value { get; set; }

        decimal CashBack { get; set; }
    }
}
