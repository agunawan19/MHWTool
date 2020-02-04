using System.Collections.Generic;

namespace Mhw.Domain.Entities
{
    public interface ISkill
    {
        short Id { get; set; }
        string Name { get; set; }
        byte MaximumLevel { get; set; }

        ICollection<SkillLevel> SkillLevels { get; set; }
    }
}