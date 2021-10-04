namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.LeaveRequests", name: "EmployeeDetailss_EmployeeID", newName: "EMP_EmployeeID");
            RenameIndex(table: "dbo.LeaveRequests", name: "IX_EmployeeDetailss_EmployeeID", newName: "IX_EMP_EmployeeID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.LeaveRequests", name: "IX_EMP_EmployeeID", newName: "IX_EmployeeDetailss_EmployeeID");
            RenameColumn(table: "dbo.LeaveRequests", name: "EMP_EmployeeID", newName: "EmployeeDetailss_EmployeeID");
        }
    }
}
