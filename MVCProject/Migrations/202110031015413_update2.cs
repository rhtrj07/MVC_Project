namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaveRequests", "LeaveType", c => c.String());
            AddColumn("dbo.LeaveRequests", "HalfDay", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeaveRequests", "HalfDay");
            DropColumn("dbo.LeaveRequests", "LeaveType");
        }
    }
}
