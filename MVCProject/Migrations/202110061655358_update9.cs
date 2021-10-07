namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeDetails", "Department", c => c.String());
            DropColumn("dbo.EmployeeDetails", "Designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeDetails", "Designation", c => c.String());
            DropColumn("dbo.EmployeeDetails", "Department");
        }
    }
}
