namespace Vinil.Business.Common.Contracts.Entities
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }

        decimal Value { get; set; }

        decimal CashBack { get; set; }
    }
}
