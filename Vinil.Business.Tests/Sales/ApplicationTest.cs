using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinil.Business.Catalogs.Contracts;
using Vinil.Business.Catalogs.Contracts.Entities;
using Vinil.Business.Catalogs.Models;
using Vinil.Business.Sales;
using Vinil.Business.Sales.Contracts;
using Vinil.Business.Sales.Contracts.Entities;
using Vinil.Business.Sales.Models;
using Vinil.Contracts.Sales.Models;
using Vinil.Models;

namespace Vinil.Business.Tests.Sales
{
    [TestClass]
    public class ApplicationTest
    {
        private readonly Application _application;
        private readonly Mock<ISalesDataContext> _dataContext;
        private readonly Mock<ICatalogsDataContext> _catalogsDataContext;

        public ApplicationTest()
        {
            _dataContext = new Mock<ISalesDataContext>();
            _catalogsDataContext = new Mock<ICatalogsDataContext>();

            _application = new Application(_dataContext.Object, _catalogsDataContext.Object);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnSales()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => new List<ISale>() { new Sale() { Items = Enumerable.Empty<ICatalog>() } }.AsQueryable());

            //Act
            var result = await _application.FilterAsync(new SalesFilter() { Page = 1, PageSize = 1 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Count(), 0);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnOneSale()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => new List<ISale>() { new Sale() { Items = Enumerable.Empty<ICatalog>() }, new Sale() { Items = Enumerable.Empty<ICatalog>() } }.AsQueryable());

            //Act
            var result = await _application.FilterAsync(new SalesFilter() { Page = 1, PageSize = 1 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnPageTwoSale()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => new List<ISale>() { new Sale() { Items = Enumerable.Empty<ICatalog>() }, new Sale() { Items = Enumerable.Empty<ICatalog>() } }.AsQueryable());

            //Act
            var result = await _application.FilterAsync(new SalesFilter() { Page = 2, PageSize = 1 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnTwoSales()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => new List<ISale>() { new Sale() { Items = Enumerable.Empty<ICatalog>() }, new Sale() { Items = Enumerable.Empty<ICatalog>() } }.AsQueryable());

            //Act
            var result = await _application.FilterAsync(new SalesFilter() { Page = 1, PageSize = 2 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnEmpty()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => Enumerable.Empty<ISale>().AsQueryable());

            //Act
            var result = await _application.FilterAsync(new SalesFilter() { Page = 1, PageSize = 1 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 0);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnOneFilteredSale()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => new List<ISale>() { new Sale() { Date = new DateTime(2019, 1, 15), Items = Enumerable.Empty<ICatalog>() }, new Sale() { Date = new DateTime(2018, 1, 15), Items = Enumerable.Empty<ICatalog>() } }.AsQueryable());

            //Act
            var result = await _application.FilterAsync(new SalesFilter() { StartDate = new DateTime(2019, 1, 1), EndDate = new DateTime(2019, 1, 31), Page = 1, PageSize = 2 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public async Task FilterAsyncShouldReturnOrderedSales()
        {
            //Arrange
            _dataContext.Setup(s => s.FindAsync()).ReturnsAsync(() => new List<ISale>() { new Sale() { Date = new DateTime(2019, 1, 15), Id = 1, Items = Enumerable.Empty<ICatalog>() }, new Sale() { Date = new DateTime(2019, 2, 15), Id = 2, Items = Enumerable.Empty<ICatalog>() } }.AsQueryable());

            //Act
            var result = await _application.FilterAsync(new SalesFilter() { Page = 1, PageSize = 2 });

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ElementAt(0).Id, 2);
        }

        [TestMethod]
        public async Task GetAsyncShouldReturnSale()
        {
            //Arrange
            _dataContext.Setup(s => s.GetAsync(It.IsAny<int>())).ReturnsAsync(() => new Sale() { Items = Enumerable.Empty<ICatalog>() });

            //Act
            var result = await _application.GetAsync(It.IsAny<int>());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ISalesModel));
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

        [TestMethod]
        public async Task RegisterSaleAsyncShouldReturnRegisteredSale()
        {
            //Arrange
            _catalogsDataContext.Setup(s => s.GetAsync(It.IsAny<int>())).ReturnsAsync(() => new Catalog());

            //Act
            var result = await _application.RegisterSaleAsync(new Models.SalesModel() { Items = new int[] { 1 } });

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ISalesModel));
        }

        [TestMethod]
        public async Task RegisterSaleAsyncShouldReturnNullWithItems()
        {
            //Arrange
            _catalogsDataContext.Setup(s => s.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            //Act
            var result = await _application.RegisterSaleAsync(new Models.SalesModel() { Items = new int[] { 1 } });

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task RegisterSaleAsyncShouldReturnNullWithoutItems()
        {
            //Arrange
            _catalogsDataContext.Setup(s => s.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            //Act
            var result = await _application.RegisterSaleAsync(new Models.SalesModel());

            //Assert
            Assert.IsNull(result);
        }
    }
}
