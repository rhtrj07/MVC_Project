namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isspeacialpermission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeDetails", "IsSpecialPermission", c => c.Boolean(nullable: false , defaultValue : false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeDetails", "IsSpecialPermission");
        }
    }
}
