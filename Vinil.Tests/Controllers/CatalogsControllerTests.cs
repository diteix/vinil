using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Vinil.Business.Catalogs.Models;
using Vinil.Contracts.Catalogs;
using Vinil.Contracts.Catalogs.Filters;
using Vinil.Contracts.Catalogs.Models;
using Vinil.Controllers;
using Vinil.Models;

namespace Vinil.Tests.Controllers
{
    [TestClass]
    public class CatalogsControllerTests
    {
        private readonly CatalogsController _controller;
        private readonly Mock<ICatalogsApplication> _catalogsApplication;

        public CatalogsControllerTests()
        {
            _catalogsApplication = new Mock<ICatalogsApplication>();

            _controller = new CatalogsController(_catalogsApplication.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Configuration = new HttpConfiguration();
        }

        [TestMethod]
        public async Task FilterShouldReturnOk()
        {
            //Arrange
            _catalogsApplication.Setup(s => s.FilterAsync(It.IsAny<ICatalogsFilter>())).ReturnsAsync(() => new List<ICatalogsModel>() { new CatalogsModel() });

            //Act
            var result = await _controller.Filter(new CatalogsFilter());
            var response = (await result.ExecuteAsync(CancellationToken.None));

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task FilterShouldReturnNotFound()
        {
            //Arrange
            _catalogsApplication.Setup(s => s.FilterAsync(It.IsAny<ICatalogsFilter>())).ReturnsAsync(() => null);

            //Act
            var result = await _controller.Filter(new CatalogsFilter());
            var response = (await result.ExecuteAsync(CancellationToken.None));

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task GetShouldReturnOk()
        {
            //Arrange
            _catalogsApplication.Setup(s => s.GetAsync(It.IsAny<int>())).ReturnsAsync(() => new CatalogsModel());

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
            _catalogsApplication.Setup(s => s.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            //Act
            var result = await _controller.Get(It.IsAny<int>());
            var response = (await result.ExecuteAsync(CancellationToken.None));

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
