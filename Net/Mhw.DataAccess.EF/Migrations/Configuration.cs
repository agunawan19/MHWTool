using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Mhw.DataAccess;
using Mhw.DataAccess.MigrationCodeGenerator;
using Mhw.Domain.Enumerations;
using Mhw.Domain.Entities;

namespace Mhw.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MhwMigrationContext>
    {
        public Configuration()
        {
            CodeGenerator = new ExtendedMigrationCodeGenerator();
            AutomaticMigrationsEnabled = false;
            ContextKey = "MHWEntity.MhwContext";
        }

        protected override void Seed(MhwMigrationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            base.Seed(context);

            context.Habitats.AddOrUpdate(
                t => t.Id,
                Enum.GetValues(typeof(HabitatEnum))
                    .OfType<HabitatEnum>()
                    .Select(t =>
                    {
                        var habitat = Habitat.CreateInstance();
                        habitat.Id = t;
                        habitat.Name = t.ToString();
                        return habitat;
                    })
                    .ToArray());

            context.MaterialTypes.AddOrUpdate(
                t => t.Id,
                Enum.GetValues(typeof(MaterialTypeEnum))
                    .OfType<MaterialTypeEnum>()
                    .Select(t => new MaterialType() { Id = t, Name = t.ToString() })
                    .ToArray());

            AddOrUpdate(context,
                GenerateMaterials(),
                t => t.Name);

            AddOrUpdate(context,
                GenerateSkills(),
                t => t.Name);

            AddOrUpdate(context,
                GenerateSkillLevels(),
                t => new { t.SkillId, t.Level });

            AddOrUpdate(context,
                GeneratePersons(),
                t => t.Name);
        }

        private static void AddOrUpdate<TEntity>(DbContext context, List<TEntity> entities,
            Expression<Func<TEntity, object>> identifierExpression = null) where TEntity : class
        {
            if (identifierExpression == null)
            {
                context.Set<TEntity>().AddOrUpdate(entities.ToArray());
            }
            else
            {
                context.Set<TEntity>().AddOrUpdate(identifierExpression, entities.ToArray());
            }
        }

        private static List<Material> GenerateMaterials() =>
            new List<Material>
            {
                new Material {Name = "Material 1", TypeId = MaterialTypeEnum.Carving, Rarity = 3},
                new Material {Name = "Material 2", TypeId = MaterialTypeEnum.Gathering, Rarity = 3},
                new Material {Name = "Material 3", TypeId = MaterialTypeEnum.Mining, Rarity = 3},
            };

        private static List<Skill> GenerateSkills() =>
            new List<Skill>
            {
                new Skill {Name = "Skill 1", MaximumLevel = 1},
                new Skill {Name = "Skill 2", MaximumLevel = 2},
                new Skill {Name = "Skill 3", MaximumLevel = 3},
                new Skill {Name = "Skill 4", MaximumLevel = 4},
                new Skill {Name = "Skill 5", MaximumLevel = 5}
            };

        private static List<SkillLevel> GenerateSkillLevels() =>
            new List<SkillLevel>
            {
                new SkillLevel
                    {Level = 1, Description = "Skill 1.1 Description", IsSecretLevel = false, SkillId = 1},
                new SkillLevel
                    {Level = 2, Description = "Skill 1.2 Description", IsSecretLevel = true, SkillId = 1},
                new SkillLevel
                    {Level = 3, Description = "Skill 1.3 Description", IsSecretLevel = true, SkillId = 1},
                new SkillLevel
                    {Level = 1, Description = "Skill 2.1 Description", IsSecretLevel = true, SkillId = 2},
                new SkillLevel
                    {Level = 2, Description = "Skill 2.2 Description", IsSecretLevel = true, SkillId = 2}
            };

        private static List<Person> GeneratePersons() =>
            new List<Person>
            {
                new Person {Name = "First Person", AddressLine = "Address 1", City = "City1", ZipCode = "12345"},
                new Person {Name = "Second Person", AddressLine = "Address 2", City = "City2", ZipCode = "23456"},
            };
    }
}