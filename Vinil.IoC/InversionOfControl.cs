using Vinil.Business.Catalogs.Contracts;
using Vinil.Business.Sales.Contracts;
using Vinil.Contracts;
using Vinil.Contracts.Catalogs;
using Vinil.Contracts.Sales;
using Vinil.CrossCutting.DependencyInjection;

namespace Vinil.IoC
{
    public class InversionOfControl : IRegisterDependencies
    {
        public void RegisterDependencies()
        {
            Injector.Register<ICatalogsApplication, Business.Catalogs.Application>();
            Injector.Register<ISalesApplication, Business.Sales.Application>();

            Injector.Register<ICatalogsDataContext, DAL.Catalogs.DataContext>();
            Injector.Register<ISalesDataContext, DAL.Sales.DataContext>();
        }
    }
}
