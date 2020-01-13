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