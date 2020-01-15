using System.Data.Entity.ModelConfiguration;
using JetBrains.Annotations;
using MhwLibrary.Models;

namespace MhwDataAccess.EntityConfigurations
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