namespace MHWEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPeople : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        PersonName = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.PersonDetails",
                c => new
                    {
                        ProprietorId = c.Int(nullable: false),
                        ZipCode = c.String(),
                        City = c.String(),
                        AddressLine = c.String(),
                    })
                .PrimaryKey(t => t.ProprietorId)
                .ForeignKey("dbo.People", t => t.ProprietorId)
                .Index(t => t.ProprietorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonDetails", "ProprietorId", "dbo.People");
            DropIndex("dbo.PersonDetails", new[] { "ProprietorId" });
            DropTable("dbo.PersonDetails");
            DropTable("dbo.People");
        }
    }
}
