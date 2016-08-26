namespace DrawNet.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reportStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "ReportStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "ReportStatus");
        }
    }
}
