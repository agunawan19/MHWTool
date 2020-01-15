using System.Data.Entity;
using MhwDataAccess.Migrations;
using MhwLibrary.Models;

namespace MhwDataAccess
{
    //[DbConfigurationType(typeof(Configuration))]
    public class MHWContext : DbContext
    {
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillLevel> SkillLevels { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        // DbContext with read-only set properties
        public virtual DbSet<Habitat> Habitats => Set<Habitat>();

        public virtual DbSet<MaterialType> MaterialTypes => Set<MaterialType>();

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