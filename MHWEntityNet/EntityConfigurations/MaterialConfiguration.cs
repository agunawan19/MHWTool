using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MHWLibrary.Models;

namespace MHWEntity.EntityConfigurations
{
    [UsedImplicitly]
    internal sealed class MaterialConfiguration : EntityTypeConfiguration<Material>
    {
        internal MaterialConfiguration()
        {
            Property(t => t.Id)
                .IsRequired()
                .IsConcurrencyToken();
            Property(t => t.Name)
                .HasMaxLength(50);

            //HasKey(t => t.Id);

            //modelBuilder
            //    .Entity<Material>()
            //    .HasRequired<MaterialType>(material => material.Type);
        }
    }
}