using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MHWLibrary.Models;

namespace MHWEntity
{
    public class MHWRepository
    {
        //public List<Department> GetDepartments()
        //{
        //    const string connectionString =
        //        "server=.;database=MHWDb;Trusted_Connection=True;MultipleActiveResultSets=True;application name=EntityFramework";
        //    var context = new MHWContext(connectionString);
        //    return context.Departments.ToList();
        //}
        //private const string ConnectionString =
        //    @"server=(localdb)\MSSQLLocalDB;database=MHWDb;Trusted_Connection=True;MultipleActiveResultSets=True;application name=EntityFramework";
        private readonly string _connectionString;

        public MHWRepository()
        {
            _connectionString =
                @"server=(localdb)\MSSQLLocalDB;database=MHWDb;Trusted_Connection=True;MultipleActiveResultSets=True;application name=EntityFramework";
        }

        public ICollection<Material> GetMaterials()
        {
            using (var context = new MHWContext(_connectionString))
            {
                return context.Materials.Include(e => e.Type).AsNoTracking().ToList();
            }
        }

        public Material GetMaterial(short id)
        {
            using (var context = new MHWContext(_connectionString))
            {
                var material = context.Materials.Find(id);
                context.Entry(material).Reference(e => e.Type).Load();

                return material;
            }
        }

        public ICollection<MaterialType> GetMaterialTypes()
        {
            using (var context = new MHWContext(_connectionString))
            {
                return context.MaterialTypes.Include(e => e.Materials).AsNoTracking().ToList();
            }
        }

        public ICollection<Skill> GetSkills()
        {
            using (var context = new MHWContext(_connectionString))
            {
                return context.Skills.Include(e => e.SkillLevels).AsNoTracking().ToList();
            }
        }

        public ICollection<Person> GetPersons()
        {
            using (var context = new MHWContext(_connectionString))
            {
                return context.Persons.ToList();
            }
        }
    }
}