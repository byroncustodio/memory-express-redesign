namespace MemoryExpress.Infrastructure.Migrations
{
    using MemoryExpress.Core.Domain.Catalog;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MemoryExpress.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MemoryExpress.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var images = new List<Image>
            {
                new Image { Id = 1, FileName = "/Content/Images/Products/MX75587-0.jpg" }
            };

            images.ForEach(s => context.Images.AddOrUpdate(p => p.FileName, s));
            context.SaveChanges();

            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer { Id = 1, Name = "G.SKILL", Description = "", LogoImage = "/Content/Images/Manufacturers/gskill.png", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now }
            };

            manufacturers.ForEach(s => context.Manufacturers.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    SKU = "MX75587",
                    ILC = "848354032724",
                    PartNumber = "F4-3600C18D-16GTRG",
                    Name = "Trident Z Royal Gold DDR4-3600 C18 RAM Kit (2x 8GB)",
                    Description = "",
                    Price = 199.99m,
                    StockQuantity = 100,
                    MaxCartQuantity = 2,
                    Published = true,
                    DateAdded = DateTime.Now,
                    DateModified = DateTime.Now,
                    Images = new List<ProductImageMapping>
                    {
                        new ProductImageMapping { ProductId = 1, ImageId = 1, SortOrder = 0, Image = context.Images.Where(i => i.Id == 1).Single() }
                    },
                    Manufacturers = new List<ProductManufacturerMapping>
                    {
                        new ProductManufacturerMapping { ProductId = 1, ManufacturerId = 1, Manufacturer = context.Manufacturers.Where(m => m.Id == 1).Single() }
                    },
                    Specifications = new List<ProductSpecificationMapping>
                    {
                        new ProductSpecificationMapping { ProductId = 1, SpecificationId = 1, SortOrder = 0,
                            Specification = new Specification { Id = 1, Name = "Make and Model", Description = "G.SKILL Trident Z Royal Gold DDR4-3600 16GB RAM Kit", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now } },
                        new ProductSpecificationMapping { ProductId = 1, SpecificationId = 2, SortOrder = 1,
                            Specification = new Specification { Id = 2, Name = "Part Number", Description = "F4-3600C18D-16GTRG", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now } },
                        new ProductSpecificationMapping { ProductId = 1, SpecificationId = 3, SortOrder = 2,
                            Specification = new Specification { Id = 3, Name = "Color", Description = "Royal Gold", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now } },
                        new ProductSpecificationMapping { ProductId = 1, SpecificationId = 4, SortOrder = 3,
                            Specification = new Specification { Id = 4, Name = "Capacity", Description = "16GB RAM Kit (2x 8GB)", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now } },
                        new ProductSpecificationMapping { ProductId = 1, SpecificationId = 5, SortOrder = 4,
                            Specification = new Specification { Id = 5, Name = "Memory Type", Description = "PC4-28800 DDR4-3600 RAM Sticks, Unbuffered, non-ECC, non-Registered RAM", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now } }
                    }
                },
            };

            // Code to only insert data with a unique Name of Product
            products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            //products.ForEach(s => context.Products.AddOrUpdate(s));
            context.SaveChanges();

            // Code to insert db if it doesn't already exist
            //foreach (Enrollment e in enrollments)
            //{
            //    var enrollmentInDataBase = context.Enrollments.Where(
            //        s =>
            //             s.Student.ID == e.StudentID &&
            //             s.Course.CourseID == e.CourseID).SingleOrDefault();
            //    if (enrollmentInDataBase == null)
            //    {
            //        context.Enrollments.Add(e);
            //    }
            //}
        }
    }
}
