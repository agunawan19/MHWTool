namespace MHWEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class1",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        Updated = c.DateTime(),
                        Created = c.DateTime(),
                        LastUserUpdate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Class1");
        }
    }
}
