using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinil.Business.Catalogs;
using Vinil.Business.Catalogs.Contracts;
using Vinil.Business.Catalogs.Contracts.Entities;
using Vinil.Business.Catalogs.Models;
using Vinil.Contracts.Catalogs.Models;
using Vinil.Models;

namespace Vinil.Business.Tests.Catalogs
{
    [TestClass]
    public class ApplicationTest
    {
        private readonly Application _application;
        private readonly Mock<ICatalogsDataContext> _dataContext;

        public ApplicationTest()
        {
            _dataContext = new Mock<ICatalogsDataContext>();

            _application = new Application(_dataContext.Object);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnCatalogs()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => new List<ICatalog>() { new Catalog() }.AsQueryable());

            //Act
            var result = await _application.FilterAsync(new CatalogsFilter() { Page = 1, PageSize = 1 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Count(), 0);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnOneCatalog()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => new List<ICatalog>() { new Catalog(), new Catalog() }.AsQueryable());

            //Act
            var result = await _application.FilterAsync(new CatalogsFilter() { Page = 1, PageSize = 1 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnPageTwoCatalog()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => new List<ICatalog>() { new Catalog(), new Catalog() }.AsQueryable());

            //Act
            var result = await _application.FilterAsync(new CatalogsFilter() { Page = 2, PageSize = 1 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnTwoCatalogs()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => new List<ICatalog>() { new Catalog(), new Catalog() }.AsQueryable());

            //Act
            var result = await _application.FilterAsync(new CatalogsFilter() { Page = 1, PageSize = 2 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnEmpty()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => Enumerable.Empty<ICatalog>().AsQueryable());

            //Act
            var result = await _application.FilterAsync(new CatalogsFilter() { Page = 1, PageSize = 1 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 0);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnOneFilteredCatalog()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => new List<ICatalog>() { new Catalog() { Genre = "pop" }, new Catalog() { Genre = "rock" } }.AsQueryable());

            //Act
            var result = await _application.FilterAsync(new CatalogsFilter() { Genre = "pop", Page = 1, PageSize = 2 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnOrderedCatalogs()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => new List<ICatalog>() { new Catalog() { Name = "ZXY" }, new Catalog() { Name = "ABC" } }.AsQueryable());

            //Act
            var result = await _application.FilterAsync(new CatalogsFilter() { Page = 1, PageSize = 2 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ElementAt(0).Name, "ABC");
        }

        [TestMethod]
        public async Task GetAsyncShouldReturnCatalog()
        {
            //Arrange
            _dataContext.Setup(s => s.GetAsync(It.IsAny<int>())).ReturnsAsync(() => new Catalog());

            //Act
            var result = await _application.GetAsync(It.IsAny<int>());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICatalogsModel));
        }

        [TestMethod]
        public async Task GetAsyncShouldReturnNull()
        {
            //Arrange
            _dataContext.Setup(s => s.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            //Act
            var result = await _application.GetAsync(It.IsAny<int>());

            //Assert
            Assert.IsNull(result);
        }
    }
}
