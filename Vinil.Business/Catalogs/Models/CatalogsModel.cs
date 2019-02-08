using System;
using Vinil.Business.Common.Models;
using Vinil.Contracts.Catalogs.Models;

namespace Vinil.Business.Catalogs.Models
{
    public class CatalogsModel : BaseModel<int>, ICatalogsModel
    {
        public CatalogsModel() { }

        public CatalogsModel(decimal cashBack)
        {
            _cashBack = cashBack;
        }

        private decimal? _cashBack;

        public string Name { get; set; }

        public string Genre { get; set; }

        new public decimal CashBack
        {
            get
            {
                return _cashBack ?? (_cashBack = Math.Round(CashBackPercentage() * Value, 2)).Value;
            }

            private set { }
        }

        public decimal CashBackPercentage()
        {
            decimal cashBackPercentage = 0;

            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    switch (Genre)
                    {
                        case "pop":
                            cashBackPercentage = 0.25M;
                            break;
                        case "mpb":
                            cashBackPercentage = 0.30M;
                            break;
                        case "classic":
                            cashBackPercentage = 0.35M;
                            break;
                        case "rock":
                            cashBackPercentage = 0.40M;
                            break;
                    }
                    break;
                case DayOfWeek.Monday:
                    switch (Genre)
                    {
                        case "pop":
                            cashBackPercentage = 0.07M;
                            break;
                        case "mpb":
                            cashBackPercentage = 0.05M;
                            break;
                        case "classic":
                            cashBackPercentage = 0.03M;
                            break;
                        case "rock":
                            cashBackPercentage = 0.10M;
                            break;
                    }
                    break;
                case DayOfWeek.Tuesday:
                    switch (Genre)
                    {
                        case "pop":
                            cashBackPercentage = 0.06M;
                            break;
                        case "mpb":
                            cashBackPercentage = 0.10M;
                            break;
                        case "classic":
                            cashBackPercentage = 0.05M;
                            break;
                        case "rock":
                            cashBackPercentage = 0.15M;
                            break;
                    }
                    break;
                case DayOfWeek.Wednesday:
                    switch (Genre)
                    {
                        case "pop":
                            cashBackPercentage = 0.02M;
                            break;
                        case "mpb":
                            cashBackPercentage = 0.15M;
                            break;
                        case "classic":
                            cashBackPercentage = 0.08M;
                            break;
                        case "rock":
                            cashBackPercentage = 0.15M;
                            break;
                    }
                    break;
                case DayOfWeek.Thursday:
                    switch (Genre)
                    {
                        case "pop":
                            cashBackPercentage = 0.10M;
                            break;
                        case "mpb":
                            cashBackPercentage = 0.20M;
                            break;
                        case "classic":
                            cashBackPercentage = 0.13M;
                            break;
                        case "rock":
                            cashBackPercentage = 0.15M;
                            break;
                    }
                    break;
                case DayOfWeek.Friday:
                    switch (Genre)
                    {
                        case "pop":
                            cashBackPercentage = 0.15M;
                            break;
                        case "mpb":
                            cashBackPercentage = 0.25M;
                            break;
                        case "classic":
                            cashBackPercentage = 0.18M;
                            break;
                        case "rock":
                            cashBackPercentage = 0.20M;
                            break;
                    }
                    break;
                case DayOfWeek.Saturday:
                    switch (Genre)
                    {
                        case "pop":
                            cashBackPercentage = 0.20M;
                            break;
                        case "mpb":
                            cashBackPercentage = 0.30M;
                            break;
                        case "classic":
                            cashBackPercentage = 0.25M;
                            break;
                        case "rock":
                            cashBackPercentage = 0.40M;
                            break;
                    }
                    break;
            }

            return cashBackPercentage;
        }
    }
}
