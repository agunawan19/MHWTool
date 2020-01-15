namespace MhwDataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
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
                        Name = c.String(nullable: false, maxLength: 50, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        ModifiedDate = c.DateTime(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "CURRENT_TIMESTAMP")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        Rarity = c.Byte(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.MaterialTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        ModifiedDate = c.DateTime(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "CURRENT_TIMESTAMP")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        PersonName = c.String(nullable: false, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.SkillLevels",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Level = c.Byte(nullable: false),
                        Description = c.String(nullable: false, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        IsSecretLevel = c.Boolean(nullable: false),
                        SkillId = c.Short(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "CURRENT_TIMESTAMP")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        MaximumLevel = c.Byte(nullable: false, defaultValue: 1,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "1")
                                },
                            }),
                        ModifiedDate = c.DateTime(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "CURRENT_TIMESTAMP")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonDetails",
                c => new
                    {
                        ProprietorId = c.Int(nullable: false),
                        ZipCode = c.String(nullable: false, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        City = c.String(nullable: false, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        AddressLine = c.String(nullable: false, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        ModifiedDate = c.DateTime(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "CURRENT_TIMESTAMP")
                                },
                            }),
                    })
                .PrimaryKey(t => t.ProprietorId)
                .ForeignKey("dbo.People", t => t.ProprietorId)
                .Index(t => t.ProprietorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonDetails", "ProprietorId", "dbo.People");
            DropForeignKey("dbo.SkillLevels", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.Materials", "TypeId", "dbo.MaterialTypes");
            DropIndex("dbo.PersonDetails", new[] { "ProprietorId" });
            DropIndex("dbo.SkillLevels", new[] { "SkillId" });
            DropIndex("dbo.Materials", new[] { "TypeId" });
            DropTable("dbo.PersonDetails",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "AddressLine",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "" },
                        }
                    },
                    {
                        "City",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "" },
                        }
                    },
                    {
                        "ModifiedDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "CURRENT_TIMESTAMP" },
                        }
                    },
                    {
                        "ZipCode",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "" },
                        }
                    },
                });
            DropTable("dbo.Skills",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "MaximumLevel",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "1" },
                        }
                    },
                    {
                        "ModifiedDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "CURRENT_TIMESTAMP" },
                        }
                    },
                    {
                        "Name",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "" },
                        }
                    },
                });
            DropTable("dbo.SkillLevels",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Description",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "" },
                        }
                    },
                    {
                        "ModifiedDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "CURRENT_TIMESTAMP" },
                        }
                    },
                });
            DropTable("dbo.People",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "PersonName",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "" },
                        }
                    },
                });
            DropTable("dbo.MaterialTypes",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ModifiedDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "CURRENT_TIMESTAMP" },
                        }
                    },
                    {
                        "Name",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "" },
                        }
                    },
                });
            DropTable("dbo.Materials",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Name",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "" },
                        }
                    },
                });
            DropTable("dbo.Habitats",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ModifiedDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "CURRENT_TIMESTAMP" },
                        }
                    },
                    {
                        "Name",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "" },
                        }
                    },
                });
        }
    }
}
