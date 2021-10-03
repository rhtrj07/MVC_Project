namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaveRequests", "EmployeeDetails_EmployeeID", c => c.Int());
            AddColumn("dbo.LeaveRequests", "EmployeeDetails_EmployeeID1", c => c.Int());
            CreateIndex("dbo.LeaveRequests", "EmployeeDetails_EmployeeID");
            CreateIndex("dbo.LeaveRequests", "EmployeeDetails_EmployeeID1");
            AddForeignKey("dbo.LeaveRequests", "EmployeeDetails_EmployeeID", "dbo.EmployeeDetails", "EmployeeID");
            AddForeignKey("dbo.LeaveRequests", "EmployeeDetails_EmployeeID1", "dbo.EmployeeDetails", "EmployeeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveRequests", "EmployeeDetails_EmployeeID1", "dbo.EmployeeDetails");
            DropForeignKey("dbo.LeaveRequests", "EmployeeDetails_EmployeeID", "dbo.EmployeeDetails");
            DropIndex("dbo.LeaveRequests", new[] { "EmployeeDetails_EmployeeID1" });
            DropIndex("dbo.LeaveRequests", new[] { "EmployeeDetails_EmployeeID" });
            DropColumn("dbo.LeaveRequests", "EmployeeDetails_EmployeeID1");
            DropColumn("dbo.LeaveRequests", "EmployeeDetails_EmployeeID");
        }
    }
}
