namespace MVCBLOG.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "SeoCategory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "SeoCategory");
        }
    }
}
