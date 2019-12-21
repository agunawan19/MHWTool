using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWEntity.EntityConfigurations
{
    class StudentConfiguration : EntityTypeConfiguration<Student>
    {
         public StudentConfiguration()
        {
            Property(s => s.StudentName)
                .IsRequired()
                .HasMaxLength(50)
                .IsConcurrencyToken();

            // Configure a one-to-one relationship between Student & StudentAddress
            HasOptional(s => s.Address) // Mark Student.Address property optional (nullable)
                .WithRequired(ad => ad.Student); // Mark StudentAddress.Student property as required (NotNull).
        }
    }
}
