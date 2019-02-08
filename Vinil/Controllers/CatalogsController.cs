using Swagger.Net.Annotations;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Vinil.Contracts.Catalogs;
using Vinil.Models;

namespace Vinil.Controllers
{
    [RoutePrefix("api/catalogs")]
    public class CatalogsController : BaseApiController
    {
        protected readonly ICatalogsApplication _catalogApplication;

        public CatalogsController(ICatalogsApplication catalogApplication)
            : base()
        {
            _catalogApplication = catalogApplication;
        }

        [Route("")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NoContent, "No catalogs were found")]
        public async Task<IHttpActionResult> Filter([FromUri] CatalogsFilter filter)
        {
            return Response(await _catalogApplication.FilterAsync(filter));
        }

        [Route("{id:int}")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NoContent, "Catalog not found")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Response(await _catalogApplication.GetAsync(id));
        }
    }
}
