using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Vinil.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Ops! Algo de errado não está certo. Entre em contato com o suporte.")
            };
        }
    }
}