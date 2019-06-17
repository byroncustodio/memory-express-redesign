namespace MemoryExpress.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDealDateNamesAndAddedDealPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deal", "StartDealDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Deal", "EndDealDate", c => c.DateTime());
            AddColumn("dbo.ProductDealMapping", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Deal", "StartDealTime");
            DropColumn("dbo.Deal", "EndDealTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deal", "EndDealTime", c => c.DateTime());
            AddColumn("dbo.Deal", "StartDealTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProductDealMapping", "Price");
            DropColumn("dbo.Deal", "EndDealDate");
            DropColumn("dbo.Deal", "StartDealDate");
        }
    }
}
