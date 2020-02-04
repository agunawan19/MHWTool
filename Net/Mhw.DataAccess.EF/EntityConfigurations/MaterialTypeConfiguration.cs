using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using JetBrains.Annotations;
using Mhw.Domain.Entities;

namespace Mhw.DataAccess.EntityConfigurations
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
                .HasMaxLength(100);

            //HasKey(t => t.Id);

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasMany(t => t.Materials);

            //MapToStoredProcedures();
        }
    }
}