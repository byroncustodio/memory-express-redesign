using MemoryExpress.Core.Domain.Catalog;
using MemoryExpress.Core.Services.Catalog;
using MemoryExpress.Infrastructure.EFRepository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryExpress.UnitTests.Services.Catalog
{
    [TestFixture]
    public class ProductService_Tests
    {
        [Test]
        public void ProductService_Test_GetAllProducts()
        {
            // Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            var productEntities = new Product[]
            {
                new Product { Id = 1, Name = "Product 1", Price = 100m },
                new Product { Id = 2, Name = "Product 2", Price = 100m },
                new Product { Id = 3, Name = "Product 3", Price = 100m }
            }
            .AsQueryable();

            mock.Setup(m => m.GetAllProducts()).Returns(productEntities.ToList());

            // Assert
            Assert.AreEqual(productEntities.Count(), mock.Object.GetAllProducts().Count());
        }

        [Test]
        public void ProductService_Test_GetProductById()
        {
            // Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            var productEntity = new Product { Id = 1, Name = "Product 1", Price = 100m };

            mock.Setup(m => m.GetProductById(productEntity.Id)).Returns(productEntity);

            // Assert
            Assert.NotNull(mock.Object.GetProductById(productEntity.Id));
        }

        [Test]
        public void ProductService_Test_GetProductBySeo()
        {
            // Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            var productEntity = new Product { Id = 1, Name = "Product 1", Price = 100m, SeoUrl = "Product-1" };

            mock.Setup(m => m.GetProductBySeo(productEntity.SeoUrl)).Returns(productEntity);

            // Assert
            Assert.NotNull(mock.Object.GetProductBySeo(productEntity.SeoUrl));
        }
    }
}
