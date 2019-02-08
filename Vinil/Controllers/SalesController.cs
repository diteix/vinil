using Swagger.Net.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Vinil.Contracts.Sales;
using Vinil.Models;

namespace Vinil.Controllers
{
    [RoutePrefix("api/sales")]
    public class SalesController : BaseApiController
    {
        protected readonly ISalesApplication _saleApplication;

        public SalesController(ISalesApplication saleApplication)
            : base()
        {
            _saleApplication = saleApplication;
        }

        [Route("")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NoContent, "No sales were found")]
        public async Task<IHttpActionResult> Filter([FromUri] SalesFilter filter)
        {
            return Response(await _saleApplication.FilterAsync(filter));
        }

        [Route("{id:int}")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NoContent, "Sale not found")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Response(await _saleApplication.GetAsync(id));
        }

        [Route("")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NoContent, "One or more of catalogs was not found")]
        public async Task<IHttpActionResult> Sell([FromBody] RegisterSaleModel registerSale)
        {
            var sale = new SalesModel()
            {
                Date = DateTime.Now,
                Items = registerSale.CatalogIds
            };

            return Response(await _saleApplication.RegisterSaleAsync(sale));
        }
    }
}
