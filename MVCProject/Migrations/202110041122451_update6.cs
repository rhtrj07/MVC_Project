namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaveRequests", "Employee_EmployeeID", c => c.Int());
            CreateIndex("dbo.LeaveRequests", "Employee_EmployeeID");
            AddForeignKey("dbo.LeaveRequests", "Employee_EmployeeID", "dbo.EmployeeDetails", "EmployeeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveRequests", "Employee_EmployeeID", "dbo.EmployeeDetails");
            DropIndex("dbo.LeaveRequests", new[] { "Employee_EmployeeID" });
            DropColumn("dbo.LeaveRequests", "Employee_EmployeeID");
        }
    }
}
