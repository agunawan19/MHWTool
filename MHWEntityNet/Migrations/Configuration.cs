using System.Collections.Generic;

namespace MHWEntity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MHWEntity.MHWContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MHWEntity.MHWContext";
        }

        protected override void Seed(MHWEntity.MHWContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            IList<Grade> grades = new List<Grade>
            {
                new Grade() { GradeName = "Grade 1", Section = "A" },
                new Grade() { GradeName = "Grade 1", Section = "B" },
                new Grade() { GradeName = "Grade 1", Section = "C" },
                new Grade() { GradeName = "Grade 2", Section = "A" },
                new Grade() { GradeName = "Grade 3", Section = "C" }
            };

            context.Grades.AddOrUpdate(grades.ToArray());

            base.Seed(context);
        }
    }
}
