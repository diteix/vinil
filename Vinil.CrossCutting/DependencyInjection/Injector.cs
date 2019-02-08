using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace Vinil.CrossCutting.DependencyInjection
{
    public class Injector
    {
        private static Container _container = new Container();

        public static void Register<TInterface, TClass>()
        {
            _container.Register(typeof(TInterface), typeof(TClass), Lifestyle.Scoped);
        }

        public static void RegisterSingleton<T>(object instance)
        {
            _container.RegisterInstance(typeof(T), instance);
        }

        public static IDependencyResolver GetApiResolver(HttpConfiguration config)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            _container.RegisterWebApiControllers(config);


            return new SimpleInjectorWebApiDependencyResolver(_container);
        }
    }
}
