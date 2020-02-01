using System.Data.Entity;
using Mhw.DataAccess;

namespace Mhw.DataAccess.Initializer
{
    public class CreateDatabaseIfNotExistsInitializer : CreateDatabaseIfNotExists<MhwMigrationContext>
    {
        protected override void Seed(MhwMigrationContext developmentContext)
        {
            //IList<Grade> grades = new List<Grade>
            //{
            //    new Grade() { GradeName = "Grade 1", Section = "A" },
            //    new Grade() { GradeName = "Grade 1", Section = "B" },
            //    new Grade() { GradeName = "Grade 1", Section = "C" },
            //    new Grade() { GradeName = "Grade 2", Section = "A" },
            //    new Grade() { GradeName = "Grade 3", Section = "C" }
            //};

            //developmentContext.Grades.AddRange(grades);

            base.Seed(developmentContext);
        }
    }
}