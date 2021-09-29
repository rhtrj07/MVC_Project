namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeDetails",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PasswordHash = c.String(maxLength: 50),
                        Mobile = c.Long(),
                        Email = c.String(),
                        Designation = c.String(),
                        ProjManagerID = c.Int(),
                        Address = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.EmployeeDetails", t => t.ProjManagerID)
                .Index(t => t.ProjManagerID);
            
            CreateTable(
                "dbo.LeaveRequests",
                c => new
                    {
                        LeaveRequestID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        ProjManagerID = c.Int(),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        LeaveStatus = c.String(),
                        EmployeeDetails_EmployeeID = c.Int(),
                        EmployeeDetails_EmployeeID1 = c.Int(),
                    })
                .PrimaryKey(t => t.LeaveRequestID)
                .ForeignKey("dbo.EmployeeDetails", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeDetails", t => t.EmployeeDetails_EmployeeID)
                .ForeignKey("dbo.EmployeeDetails", t => t.EmployeeDetails_EmployeeID1)
                .Index(t => t.EmployeeID)
                .Index(t => t.EmployeeDetails_EmployeeID)
                .Index(t => t.EmployeeDetails_EmployeeID1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeDetails", "ProjManagerID", "dbo.EmployeeDetails");
            DropForeignKey("dbo.LeaveRequests", "EmployeeDetails_EmployeeID1", "dbo.EmployeeDetails");
            DropForeignKey("dbo.LeaveRequests", "EmployeeDetails_EmployeeID", "dbo.EmployeeDetails");
            DropForeignKey("dbo.LeaveRequests", "EmployeeID", "dbo.EmployeeDetails");
            DropIndex("dbo.LeaveRequests", new[] { "EmployeeDetails_EmployeeID1" });
            DropIndex("dbo.LeaveRequests", new[] { "EmployeeDetails_EmployeeID" });
            DropIndex("dbo.LeaveRequests", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeDetails", new[] { "ProjManagerID" });
            DropTable("dbo.LeaveRequests");
            DropTable("dbo.EmployeeDetails");
        }
    }
}
