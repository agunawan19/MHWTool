using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MHWEntity.EntityConfigurations;
using MHWEntity.Initializer;
using MHWEntity.Migrations;
using MHWLibrary.Models;

namespace MHWEntity
{
    //[DbConfigurationType(typeof(Configuration))]
    public sealed class MHWContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<Person> Persons { get; set; }

        // DbContext with read-only set properties
        public DbSet<Habitat> Habitats => Set<Habitat>();

        public DbSet<MaterialType> MaterialTypes => Set<MaterialType>();

        public MHWContext() : base("MHWDb")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MHWContext, Configuration>());
            //Database.SetInitializer(new MHWDbInitializer());
        }

        internal MHWContext(string connectionString) : base(connectionString)
        {
            //Database.SetInitializer(new MHWDbInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MHWContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = GetType().Assembly;
            modelBuilder.Configurations.AddFromAssembly(assembly);
            modelBuilder.Conventions.AddFromAssembly(assembly);
        }
    }
}