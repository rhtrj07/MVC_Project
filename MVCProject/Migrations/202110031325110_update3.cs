namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LeaveRequests", "HalfDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LeaveRequests", "HalfDay", c => c.Boolean(nullable: false));
        }
    }
}
