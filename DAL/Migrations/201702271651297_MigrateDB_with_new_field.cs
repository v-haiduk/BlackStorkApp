namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB_with_new_field : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PathForFolderWithPhotos", c => c.String());
            AddColumn("dbo.Topics", "PathForMainPhoto", c => c.String());
            AddColumn("dbo.Topics", "PathForFolderWithPhotos", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Topics", "PathForFolderWithPhotos");
            DropColumn("dbo.Topics", "PathForMainPhoto");
            DropColumn("dbo.Products", "PathForFolderWithPhotos");
        }
    }
}
