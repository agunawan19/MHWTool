using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Mhw.DataAccess.Initializer;
using Mhw.DataAccess.Migrations;
using Mhw.Domain.Entities;

namespace Mhw.DataAccess
{
    //[DbConfigurationType(typeof(Configuration))]
    public class MhwContext : MhwMigrationContext
    {
        //public virtual DbSet<Material> Materials { get; set; }
        //public virtual DbSet<Skill> Skills { get; set; }
        //public virtual DbSet<SkillLevel> SkillLevels { get; set; }
        //public virtual DbSet<Person> Persons { get; set; }

        //// DbContext with read-only set properties
        //public virtual DbSet<Habitat> Habitats => Set<Habitat>();

        //public virtual DbSet<MaterialType> MaterialTypes => Set<MaterialType>();
        //private readonly bool useConfiguration = false;

        public MhwContext() : base("MHWDb")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MhwDevelopmentContext, Configuration>());
            //Database.SetInitializer(new MHWDbInitializer());
            //Database.SetInitializer(new CreateDatabaseIfNotExistsInitializer());
            Database.SetInitializer<MhwContext>(null);
        }

        internal MhwContext(string connectionString) : base(connectionString)
        {
            //Database.SetInitializer(new MHWDbInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MhwDevelopmentContext, Configuration>());
            Database.SetInitializer<MhwContext>(null);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var assembly = GetType().Assembly;
        //    modelBuilder.Configurations.AddFromAssembly(assembly);
        //    modelBuilder.Conventions.AddFromAssembly(assembly);
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var assembly = GetType().Assembly;
            modelBuilder.Configurations.AddFromAssembly(assembly);
        }

        //public override int SaveChanges()
        //{
        //    var entries = ChangeTracker.Entries()
        //        .Where(e => e.Entity is EntityBase &&
        //                    (e.State == EntityState.Added || e.State == EntityState.Modified));

        //    foreach (var entityEntry in entries)
        //    {
        //        ((EntityBase)entityEntry.Entity).ModifiedDate = DateTime.Now;

        //        //if (entityEntry.State == EntityState.Added)
        //        //{
        //        //    ((EntityBase)entityEntry.Entity).CreatedDate = DateTime.Now;
        //        //}
        //    }

        //    return base.SaveChanges();
        //}
    }
}