using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using JetBrains.Annotations;
using Mhw.Domain.Entities;

namespace Mhw.DataAccess.EntityConfigurations
{
    [UsedImplicitly]
    internal sealed class HabitatConfiguration : EntityTypeConfiguration<Habitat>
    {
        internal HabitatConfiguration()
        {
            //Property(t => t.Id)
            //    .IsRequired()
            //    .IsConcurrencyToken();
            //MapToStoredProcedures();

            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            //HasKey(t => t.Id);

            //Property(t => t.ModifiedDate)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
            //    .HasColumnAnnotation("DefaultValueSql", "CURRENT_TIMESTAMP")
            //    .HasColumnType("datetime2");

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}