﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWEntity.Initializer
{
    public class MHWDbInitializer : DropCreateDatabaseIfModelChanges<MHWContext>
    {
        protected override void Seed(MHWContext context)
        {
            //IList<Grade> grades = new List<Grade>
            //{
            //    new Grade() { GradeName = "Grade 1", Section = "A" },
            //    new Grade() { GradeName = "Grade 1", Section = "B" },
            //    new Grade() { GradeName = "Grade 1", Section = "C" },
            //    new Grade() { GradeName = "Grade 2", Section = "A" },
            //    new Grade() { GradeName = "Grade 3", Section = "C" }
            //};

            //context.Grades.AddRange(grades);

            base.Seed(context);
        }
    }
}