namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB_10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colours",
                c => new
                    {
                        ColourId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PathForImage = c.String(),
                    })
                .PrimaryKey(t => t.ColourId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        PathForMainPhoto = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Description = c.String(),
                        DateOfCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TopicId);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserAccountId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        HashOfPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserAccountId);
            
            CreateTable(
                "dbo.EmailSendings",
                c => new
                    {
                        UserProfileId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserProfileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailSendings");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Topics");
            DropTable("dbo.Roles");
            DropTable("dbo.Products");
            DropTable("dbo.Colours");
        }
    }
}
