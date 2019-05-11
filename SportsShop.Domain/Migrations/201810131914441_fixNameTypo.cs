namespace SportsShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixNameTypo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageData", c => c.Binary());
            DropColumn("dbo.Products", "ImageDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImageDate", c => c.Binary());
            DropColumn("dbo.Products", "ImageData");
        }
    }
}
