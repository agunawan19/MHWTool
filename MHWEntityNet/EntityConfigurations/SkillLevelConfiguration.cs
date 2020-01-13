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