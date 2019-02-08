using Vinil.Business.Common.Contracts.Entities;

namespace Vinil.DAL.Common.Entities
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public decimal Value { get; set; }

        public decimal CashBack { get; set; }
    }
}
