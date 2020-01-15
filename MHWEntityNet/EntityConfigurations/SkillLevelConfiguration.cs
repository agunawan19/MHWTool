using System.Data.Entity.ModelConfiguration;
using JetBrains.Annotations;
using MhwLibrary.Models;

namespace MhwDataAccess.EntityConfigurations
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
        }
    }
}