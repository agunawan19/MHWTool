using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MHWLibrary.Models;

namespace MHWEntity.EntityConfigurations
{
    [UsedImplicitly]
    internal sealed class MaterialTypeConfiguration : EntityTypeConfiguration<MaterialType>
    {
        internal MaterialTypeConfiguration()
        {
            //Property(t => t.Id)
            //    .IsRequired()
            //    .IsConcurrencyToken();
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            //HasKey(t => t.Id);

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasMany(t => t.Materials);
        }
    }
}