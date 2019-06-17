namespace MemoryExpress.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDealTableAndMapping : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DealType = c.Int(nullable: false),
                        Published = c.Boolean(nullable: false),
                        StartDealTime = c.DateTime(nullable: false),
                        EndDealTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductDealMapping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        DealId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deal", t => t.DealId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.DealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDealMapping", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductDealMapping", "DealId", "dbo.Deal");
            DropIndex("dbo.ProductDealMapping", new[] { "DealId" });
            DropIndex("dbo.ProductDealMapping", new[] { "ProductId" });
            DropTable("dbo.ProductDealMapping");
            DropTable("dbo.Deal");
        }
    }
}
