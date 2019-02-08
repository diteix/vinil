using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Vinil.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected IHttpActionResult Response<T>(T content)
        {
            return content == null || (content as IEnumerable<object>)?.Count() == 0 ? Content(HttpStatusCode.NoContent, "No Content") : Ok(content) as IHttpActionResult;
        }
    }
}
