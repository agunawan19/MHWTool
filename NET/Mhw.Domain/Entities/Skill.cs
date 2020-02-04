using System.Collections.Generic;

namespace Mhw.Domain.Entities
{
    public class Skill : EntityBase, ISkill
    {
        public short Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte MaximumLevel { get; set; } = 1;

        public ICollection<SkillLevel> SkillLevels { get; set; } = new List<SkillLevel>();
    }
}