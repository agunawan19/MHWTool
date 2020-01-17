using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWEntity.Models;

namespace MHWEntity.EntityConfigurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            Property(s => s.Id)
                .IsRequired()
                .IsConcurrencyToken();
        }
    }
}
