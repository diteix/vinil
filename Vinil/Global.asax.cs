using System.Net.Http.Formatting;
using System.Web.Http;
using Vinil.App_Start;
using Vinil.Filters;

namespace Vinil
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configure(DependencyRegister.Register);

            GlobalConfiguration.Configuration.Filters.Add(new ApiExceptionFilterAttribute());

            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
