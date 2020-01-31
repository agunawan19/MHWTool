using System.Data.Entity.ModelConfiguration;
using JetBrains.Annotations;
using Mhw.Library.Models;

namespace Mhw.DataAccess.EntityConfigurations
{
    [UsedImplicitly]
    internal sealed class SkillLevelConfiguration : EntityTypeConfiguration<SkillLevel>
    {
        internal SkillLevelConfiguration()
        {
            //Property(t => t.Id)
            //    .IsRequired()
            //    .IsConcurrencyToken();

            //HasKey(t => t.Id);
            Property(t => t.Description)
                .HasMaxLength(1000);

            Property(t => t.SkillId).IsOptional();
        }
    }
}