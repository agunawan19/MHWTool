using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWEntity.Conventions
{
    internal class DefaultValueConvention : Convention
    {
        internal DefaultValueConvention()
        {
            //Properties()
            //    .Where(p => p.Name == p.DeclaringType?.Name + "_ID")
            //    .Configure(p => p.IsKey());
            Properties()
                .Where(p => p.PropertyType.Name == "String")
                .Configure(p =>
                    p.IsRequired()
                        .HasColumnAnnotation("DefaultValue", string.Empty)
                );

            Properties()
                .Where(p => p.PropertyType.Name == "DateTime")
                .Configure(p => p
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                    .HasColumnAnnotation("DefaultValueSql", "CURRENT_TIMESTAMP")
                );
        }
    }
}