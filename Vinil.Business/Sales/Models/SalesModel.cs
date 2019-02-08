using System;
using System.Collections.Generic;
using System.Linq;
using Vinil.Business.Common.Models;
using Vinil.Contracts.Catalogs.Models;
using Vinil.Contracts.Sales.Models;

namespace Vinil.Business.Sales.Models
{
    public class SalesModel : BaseModel<int>, ISalesModel
    {
        private decimal? _value;

        private decimal? _cashBack;

        public SalesModel() { }

        public SalesModel(decimal value, decimal cashBack)
        {
            Value = value;
            CashBack = cashBack;
        }

        public IEnumerable<ICatalogsModel> Items { get; set; }

        public DateTime Date { get; set; }

        new public decimal Value
        {
            get
            {
                return _value ?? (_value = Items.Sum(s => s.Value)).Value;
            }

            private set { _value = value; }
        }

        new public decimal CashBack
        {
            get
            {
                return _cashBack ?? (_cashBack = Items.Sum(s => s.CashBack)).Value;
            }

            private set { _cashBack = value; }
        }
    }
}
