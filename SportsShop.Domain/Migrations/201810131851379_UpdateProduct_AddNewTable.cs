namespace SportsShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProduct_AddNewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Identities",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Products", "Note", c => c.String());
            AddColumn("dbo.Products", "ImageDate", c => c.Binary());
            AddColumn("dbo.Products", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageMimeType");
            DropColumn("dbo.Products", "ImageDate");
            DropColumn("dbo.Products", "Note");
            DropTable("dbo.Identities");
        }
    }
}
