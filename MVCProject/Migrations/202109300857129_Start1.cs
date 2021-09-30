namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeDetails", "PasswordHash", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeDetails", "PasswordHash", c => c.String(maxLength: 50));
        }
    }
}
