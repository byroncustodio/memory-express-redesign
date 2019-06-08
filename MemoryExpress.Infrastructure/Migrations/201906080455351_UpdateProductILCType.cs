namespace MemoryExpress.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductILCType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "ILC", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "ILC", c => c.Long(nullable: false));
        }
    }
}
