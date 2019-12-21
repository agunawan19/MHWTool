using System.Data.Entity.ModelConfiguration;
using MHWEntity.Models;

namespace MHWEntity.EntityConfigurations
{
    internal class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            Property(s => s.Id)
                .IsRequired()
                .IsConcurrencyToken();

            HasOptional(s => s.Employees);
        }
    }
}