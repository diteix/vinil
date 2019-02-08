using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Vinil.Contracts.Sales;
using Vinil.Contracts.Sales.Filters;
using Vinil.Contracts.Sales.Models;
using Vinil.Controllers;
using Vinil.Models;

namespace Vinil.Tests.Controllers
{
    [TestClass]
    public class SalesControllerTests
    {
        private readonly SalesController _controller;
        private readonly Mock<ISalesApplication> _salesApplication;

        public SalesControllerTests()
        {
            _salesApplication = new Mock<ISalesApplication>();

            _controller = new SalesController(_salesApplication.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Configuration = new HttpConfiguration();
        }

        [TestMethod]
        public async Task FilterShouldReturnOk()
        {
            //Arrange
            _salesApplication.Setup(s => s.FilterAsync(It.IsAny<ISalesFilter>())).ReturnsAsync(() => new List<ISalesModel>() { new Business.Sales.Models.SalesModel() });

            //Act
            var result = await _controller.Filter(new SalesFilter());
            var response = (await result.ExecuteAsync(CancellationToken.None));

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task FilterShouldReturnNotFound()
        {
            //Arrange
            _salesApplication.Setup(s => s.FilterAsync(It.IsAny<ISalesFilter>())).ReturnsAsync(() => null);

            //Act
            var result = await _controller.Filter(new SalesFilter());
            var response = (await result.ExecuteAsync(CancellationToken.None));

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task GetShouldReturnOk()
        {
            //Arrange
            _salesApplication.Setup(s => s.GetAsync(It.IsAny<int>())).ReturnsAsync(() => new Business.Sales.Models.SalesModel());

            //Act
            var result = await _controller.Get(It.IsAny<int>());
            var response = (await result.ExecuteAsync(CancellationToken.None));

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetShouldReturnNotFound()
        {
            //Arrange
            _salesApplication.Setup(s => s.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            //Act
            var result = await _controller.Get(It.IsAny<int>());
            var response = (await result.ExecuteAsync(CancellationToken.None));

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task SellShouldReturnOk()
        {
            //Arrange
            _salesApplication.Setup(s => s.RegisterSaleAsync(It.IsAny<IRegisterSaleModel>())).ReturnsAsync(() => new Business.Sales.Models.SalesModel());

            //Act
            var result = await _controller.Sell(new RegisterSaleModel());
            var response = (await result.ExecuteAsync(CancellationToken.None));

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task SellShouldReturnNotFound()
        {
            //Arrange
            _salesApplication.Setup(s => s.RegisterSaleAsync(It.IsAny<IRegisterSaleModel>())).ReturnsAsync(() => null);

            //Act
            var result = await _controller.Sell(new RegisterSaleModel());
            var response = (await result.ExecuteAsync(CancellationToken.None));

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
