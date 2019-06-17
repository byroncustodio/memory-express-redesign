using MemoryExpress.Core.Domain.Catalog;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MemoryExpress.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("MemoryExpressContextDb")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategoryMapping> ProductCategoryMappings { get; set; }
        public DbSet<ProductDealMapping> ProductDealMappings { get; set; }
        public DbSet<ProductImageMapping> ProductImageMappings { get; set; }
        public DbSet<ProductManufacturerMapping> ProductManufacturerMappings { get; set; }
        public DbSet<ProductSpecificationMapping> ProductSpecificationMappings { get; set; }
        public DbSet<Specification> Specifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Deal>().ToTable("Deal");
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductCategoryMapping>().ToTable("ProductCategoryMapping");
            modelBuilder.Entity<ProductDealMapping>().ToTable("ProductDealMapping");
            modelBuilder.Entity<ProductImageMapping>().ToTable("ProductImageMapping");
            modelBuilder.Entity<ProductManufacturerMapping>().ToTable("ProductManufacturerMapping");
            modelBuilder.Entity<ProductSpecificationMapping>().ToTable("ProductSpecificationMapping");
            modelBuilder.Entity<Specification>().ToTable("Specification");
        }
    }
}