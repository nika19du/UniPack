namespace CRUDWithEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ImageUrl", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ImageUrl");
        }
    }
}
