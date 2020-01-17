using System.Collections.Generic;

namespace Mhw.Library.Models
{
    public interface ISkill
    {
        short Id { get; set; }
        string Name { get; set; }
        byte MaximumLevel { get; set; }

        ICollection<SkillLevel> SkillLevels { get; set; }
    }
}