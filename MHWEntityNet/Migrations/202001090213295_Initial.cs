namespace MHWEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Habitats",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Rarity = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkillLevels",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Level = c.Byte(nullable: false),
                        Description = c.String(),
                        IsSecretLevel = c.Boolean(nullable: false),
                        SkillId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        MaximumLevel = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkillLevels", "SkillId", "dbo.Skills");
            DropIndex("dbo.SkillLevels", new[] { "SkillId" });
            DropTable("dbo.Skills");
            DropTable("dbo.SkillLevels");
            DropTable("dbo.Materials");
            DropTable("dbo.Habitats");
        }
    }
}
