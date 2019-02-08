using Vinil.Contracts.Common.Models;

namespace Vinil.Business.Common.Models
{
    public abstract class BaseModel<TKey> : IBaseModel<TKey>
    {
        public TKey Id { get; set; }

        public decimal Value { get; set; }

        public decimal CashBack { get; set; }
    }
}
