using System;
using System.IO;
using System.Reflection;
using System.Web.Http;
using Vinil.Contracts;
using Vinil.CrossCutting.DependencyInjection;

namespace Vinil.App_Start
{
    public static class DependencyRegister
    {
        public static void Register(HttpConfiguration config)
        {
            config.DependencyResolver = Injector.GetApiResolver(GlobalConfiguration.Configuration);

            var iocAssembly = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\Vinil.IoC\\bin\\Debug\\Vinil.IoC.dll"));

            AppDomain.CurrentDomain.Load(iocAssembly.GetName());

            var iocInstance = iocAssembly.CreateInstance("Vinil.IoC.InversionOfControl") as IRegisterDependencies;

            iocInstance.RegisterDependencies();
        }
    }
}