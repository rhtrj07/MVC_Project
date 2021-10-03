namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeDetails", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeDetails", "ImageURL", c => c.String(maxLength: 50));
        }
    }
}
