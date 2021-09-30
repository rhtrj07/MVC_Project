namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeDetails", "ImageURL", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeDetails", "ImageURL");
        }
    }
}
