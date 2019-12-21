using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MHWEntity.EntityConfigurations;
using MHWEntity.Initializer;
using MHWEntity.Migrations;
using MHWEntity.Models;

namespace MHWEntity
{
    //[DbConfigurationType(typeof(Configuration))]
    public class MHWContext : DbContext
    {
        public MHWContext() : base("MHWDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MHWContext, Configuration>());
            Database.SetInitializer(new MHWDbInitializer());
        }

        public MHWContext(string connectionString) : base(connectionString)
        {
            //Database.SetInitializer(new MHWDbInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MHWContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .Add(new StudentConfiguration())
                //.Add(new DepartmentConfiguration())
                //.Add(new EmployeeConfiguration())
            ;
            modelBuilder.Entity<Teacher>().ToTable("TeacherInfo");
            modelBuilder.Entity<Teacher>().MapToStoredProcedures();
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class1> Class1s { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
    }
}
