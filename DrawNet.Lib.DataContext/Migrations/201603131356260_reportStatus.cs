using System.Data.Entity.Migrations;

namespace DrawNet.Lib.DataContext.Migrations
{
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
