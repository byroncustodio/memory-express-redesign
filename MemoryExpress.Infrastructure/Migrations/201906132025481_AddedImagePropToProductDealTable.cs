namespace MemoryExpress.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagePropToProductDealTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDealMapping", "MainImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductDealMapping", "MainImage");
        }
    }
}
