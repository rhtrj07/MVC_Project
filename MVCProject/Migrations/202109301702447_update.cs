namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LeaveRequests", "EmployeeDetails_EmployeeID", "dbo.EmployeeDetails");
            DropForeignKey("dbo.LeaveRequests", "EmployeeDetails_EmployeeID1", "dbo.EmployeeDetails");
            DropIndex("dbo.LeaveRequests", new[] { "EmployeeDetails_EmployeeID" });
            DropIndex("dbo.LeaveRequests", new[] { "EmployeeDetails_EmployeeID1" });
            DropColumn("dbo.LeaveRequests", "EmployeeDetails_EmployeeID");
            DropColumn("dbo.LeaveRequests", "EmployeeDetails_EmployeeID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LeaveRequests", "EmployeeDetails_EmployeeID1", c => c.Int());
            AddColumn("dbo.LeaveRequests", "EmployeeDetails_EmployeeID", c => c.Int());
            CreateIndex("dbo.LeaveRequests", "EmployeeDetails_EmployeeID1");
            CreateIndex("dbo.LeaveRequests", "EmployeeDetails_EmployeeID");
            AddForeignKey("dbo.LeaveRequests", "EmployeeDetails_EmployeeID1", "dbo.EmployeeDetails", "EmployeeID");
            AddForeignKey("dbo.LeaveRequests", "EmployeeDetails_EmployeeID", "dbo.EmployeeDetails", "EmployeeID");
        }
    }
}
