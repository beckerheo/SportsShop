namespace SportsShop.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIdentities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Identities", "PasswordHash", c => c.String(nullable: false));
            AlterColumn("dbo.Identities", "Username", c => c.String(nullable: false));
            DropColumn("dbo.Identities", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Identities", "Password", c => c.String());
            AlterColumn("dbo.Identities", "Username", c => c.String());
            DropColumn("dbo.Identities", "PasswordHash");
        }
    }
}
