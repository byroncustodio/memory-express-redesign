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
    public class CategoryService_Tests
    {
        [Test]
        public void CategoryService_Test_GetAllCategories()
        {
            // Arrange
            Mock<ICategoryService> mock = new Mock<ICategoryService>();
            var categoryEntities = new Category[]
            {
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 2, Name = "Category 2" },
                new Category { Id = 3, Name = "Category 3" },
                new Category { Id = 4, Name = "Category 4", ParentCategoryId = 2 },
                new Category { Id = 5, Name = "Category 5", ParentCategoryId = 2 },
                new Category { Id = 6, Name = "Category 6", ParentCategoryId = 3 },
            }
            .AsQueryable();

            mock.Setup(m => m.GetAllCategories()).Returns(categoryEntities.ToList());

            // Assert
            Assert.AreEqual(categoryEntities.Count(), mock.Object.GetAllCategories().Count());
        }

        [Test]
        public void CategoryService_Test_GetAllCategoriesWithoutParent()
        {
            // Arrange
            Mock<ICategoryService> mock = new Mock<ICategoryService>();
            var categoryEntities = new Category[]
            {
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 2, Name = "Category 2" },
                new Category { Id = 3, Name = "Category 3" },
                new Category { Id = 4, Name = "Category 4", ParentCategoryId = 2 },
                new Category { Id = 5, Name = "Category 5", ParentCategoryId = 2 },
                new Category { Id = 6, Name = "Category 6", ParentCategoryId = 3 },
            }
            .AsQueryable();

            mock.Setup(m => m.GetAllCategoriesWithoutParent()).Returns(categoryEntities.Take(1).ToList());

            // Assert
            Assert.AreEqual(1, mock.Object.GetAllCategoriesWithoutParent().Count());
        }

        [Test]
        public void CategoryService_Test_GetCategoryById()
        {
            // Arrange
            Mock<ICategoryService> mock = new Mock<ICategoryService>();
            var categoryEntity = new Category { Id = 1, Name = "Category 1" };

            mock.Setup(m => m.GetCategoryById(categoryEntity.Id)).Returns(categoryEntity);

            // Assert
            Assert.NotNull(mock.Object.GetCategoryById(categoryEntity.Id));
        }

        [Test]
        public void CategoryService_Test_GetCategoryBySeo()
        {
            // Arrange
            Mock<ICategoryService> mock = new Mock<ICategoryService>();
            var categoryEntity = new Category { Id = 1, Name = "Category 1", SeoUrl = "Category-1" };

            mock.Setup(m => m.GetCategoryBySeo(categoryEntity.SeoUrl)).Returns(categoryEntity);

            // Assert
            Assert.NotNull(mock.Object.GetCategoryBySeo(categoryEntity.SeoUrl));
        }
    }
}
