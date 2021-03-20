namespace Mhw.DataAccess.Migrations
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
                "dbo.Habitat",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        CreatedUtcDate = c.DateTime(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()", storeType: "datetime2",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETUTCDATE()")
                                },
                            }),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, defaultValueSql: "CURRENT_TIMESTAMP", storeType: "datetime2",
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
                "dbo.Material",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        Rarity = c.Byte(nullable: false),
                        TypeId = c.Int(nullable: false),
                        CreatedUtcDate = c.DateTime(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()", storeType: "datetime2",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETUTCDATE()")
                                },
                            }),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, defaultValueSql: "CURRENT_TIMESTAMP", storeType: "datetime2",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "CURRENT_TIMESTAMP")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialType", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.MaterialType",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        CreatedUtcDate = c.DateTime(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()", storeType: "datetime2",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETUTCDATE()")
                                },
                            }),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, defaultValueSql: "CURRENT_TIMESTAMP", storeType: "datetime2",
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
                        PersonName = c.String(nullable: false, maxLength: 100, defaultValue: "",
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
                "dbo.SkillLevel",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Level = c.Byte(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        IsSecretLevel = c.Boolean(nullable: false, defaultValue: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "False")
                                },
                            }),
                        SkillId = c.Short(),
                        CreatedUtcDate = c.DateTime(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()", storeType: "datetime2",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETUTCDATE()")
                                },
                            }),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, defaultValueSql: "CURRENT_TIMESTAMP", storeType: "datetime2",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "CURRENT_TIMESTAMP")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skill", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, defaultValue: "",
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
                        CreatedUtcDate = c.DateTime(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()", storeType: "datetime2",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETUTCDATE()")
                                },
                            }),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, defaultValueSql: "CURRENT_TIMESTAMP", storeType: "datetime2",
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
                        ZipCode = c.String(nullable: false, maxLength: 10, unicode: false, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        City = c.String(nullable: false, maxLength: 50, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        AddressLine = c.String(nullable: false, maxLength: 200, defaultValue: "",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "")
                                },
                            }),
                        CreatedUtcDate = c.DateTime(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()", storeType: "datetime2",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETUTCDATE()")
                                },
                            }),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, defaultValueSql: "CURRENT_TIMESTAMP", storeType: "datetime2",
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
            DropForeignKey("dbo.SkillLevel", "SkillId", "dbo.Skill");
            DropForeignKey("dbo.Material", "TypeId", "dbo.MaterialType");
            DropIndex("dbo.PersonDetails", new[] { "ProprietorId" });
            DropIndex("dbo.SkillLevel", new[] { "SkillId" });
            DropIndex("dbo.Material", new[] { "TypeId" });
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
                        "CreatedUtcDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETUTCDATE()" },
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
            DropTable("dbo.Skill",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedUtcDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETUTCDATE()" },
                        }
                    },
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
            DropTable("dbo.SkillLevel",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedUtcDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETUTCDATE()" },
                        }
                    },
                    {
                        "Description",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "" },
                        }
                    },
                    {
                        "IsSecretLevel",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "False" },
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
            DropTable("dbo.MaterialType",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedUtcDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETUTCDATE()" },
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
            DropTable("dbo.Material",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedUtcDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETUTCDATE()" },
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
            DropTable("dbo.Habitat",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedUtcDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETUTCDATE()" },
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
        }
    }
}
