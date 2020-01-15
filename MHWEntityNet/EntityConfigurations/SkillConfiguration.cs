using System.Data.Entity.ModelConfiguration;
using JetBrains.Annotations;
using MhwLibrary.Models;

namespace MhwDataAccess.EntityConfigurations
{
    [UsedImplicitly]
    internal sealed class SkillConfiguration : EntityTypeConfiguration<Skill>
    {
        internal SkillConfiguration()
        {
            Property(t => t.Id)
                .IsRequired()
                .IsConcurrencyToken();
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
            Property(t => t.MaximumLevel)
                .HasColumnAnnotation("DefaultValue", 1);

            //HasKey(t => t.Id);

            //modelBuilder.Entity<Skill>()
            //    .HasMany(skill => skill.SkillLevels)
            //    .WithRequired(skillLevel => skillLevel.Skill)
            //    .HasForeignKey(skillLevel => skillLevel.SkillId);
            HasMany(t => t.SkillLevels);
        }
    }
}