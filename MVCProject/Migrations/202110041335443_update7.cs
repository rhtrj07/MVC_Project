namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update7 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.LeaveRequests", name: "Employee_EmployeeID", newName: "EmployeeDetailss_EmployeeID");
            RenameIndex(table: "dbo.LeaveRequests", name: "IX_Employee_EmployeeID", newName: "IX_EmployeeDetailss_EmployeeID");
            AddColumn("dbo.LeaveRequests", "EmployeeDetails_EmployeeID", c => c.Int());
            CreateIndex("dbo.LeaveRequests", "EmployeeDetails_EmployeeID");
            AddForeignKey("dbo.LeaveRequests", "EmployeeDetails_EmployeeID", "dbo.EmployeeDetails", "EmployeeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveRequests", "EmployeeDetails_EmployeeID", "dbo.EmployeeDetails");
            DropIndex("dbo.LeaveRequests", new[] { "EmployeeDetails_EmployeeID" });
            DropColumn("dbo.LeaveRequests", "EmployeeDetails_EmployeeID");
            RenameIndex(table: "dbo.LeaveRequests", name: "IX_EmployeeDetailss_EmployeeID", newName: "IX_Employee_EmployeeID");
            RenameColumn(table: "dbo.LeaveRequests", name: "EmployeeDetailss_EmployeeID", newName: "Employee_EmployeeID");
        }
    }
}
