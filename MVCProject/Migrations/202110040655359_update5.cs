namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeDetails", "Role", c => c.String());
            DropColumn("dbo.EmployeeDetails", "Roll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeDetails", "Roll", c => c.String());
            DropColumn("dbo.EmployeeDetails", "Role");
        }
    }
}
