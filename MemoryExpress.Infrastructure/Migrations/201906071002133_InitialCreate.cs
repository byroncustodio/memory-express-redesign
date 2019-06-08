namespace MemoryExpress.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SeoUrl = c.String(),
                        MetaTitle = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        Published = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        ParentCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        LogoImage = c.String(),
                        SeoUrl = c.String(),
                        MetaTitle = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        Published = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategoryMapping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SKU = c.String(),
                        ILC = c.Long(nullable: false),
                        PartNumber = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockQuantity = c.Int(nullable: false),
                        MaxCartQuantity = c.Int(nullable: false),
                        SeoUrl = c.String(),
                        MetaTitle = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        Published = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImageMapping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Image", t => t.ImageId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.ProductManufacturerMapping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.ProductSpecificationMapping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SpecificationId = c.Int(nullable: false),
                        Value = c.String(),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Specification", t => t.SpecificationId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.Specification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Published = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSpecificationMapping", "SpecificationId", "dbo.Specification");
            DropForeignKey("dbo.ProductSpecificationMapping", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductManufacturerMapping", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductManufacturerMapping", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.ProductImageMapping", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductImageMapping", "ImageId", "dbo.Image");
            DropForeignKey("dbo.ProductCategoryMapping", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductCategoryMapping", "CategoryId", "dbo.Category");
            DropIndex("dbo.ProductSpecificationMapping", new[] { "SpecificationId" });
            DropIndex("dbo.ProductSpecificationMapping", new[] { "ProductId" });
            DropIndex("dbo.ProductManufacturerMapping", new[] { "ManufacturerId" });
            DropIndex("dbo.ProductManufacturerMapping", new[] { "ProductId" });
            DropIndex("dbo.ProductImageMapping", new[] { "ImageId" });
            DropIndex("dbo.ProductImageMapping", new[] { "ProductId" });
            DropIndex("dbo.ProductCategoryMapping", new[] { "CategoryId" });
            DropIndex("dbo.ProductCategoryMapping", new[] { "ProductId" });
            DropTable("dbo.Specification");
            DropTable("dbo.ProductSpecificationMapping");
            DropTable("dbo.ProductManufacturerMapping");
            DropTable("dbo.ProductImageMapping");
            DropTable("dbo.Product");
            DropTable("dbo.ProductCategoryMapping");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.Image");
            DropTable("dbo.Category");
        }
    }
}
