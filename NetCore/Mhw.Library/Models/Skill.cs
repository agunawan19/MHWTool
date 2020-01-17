using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Models;

namespace MHWLibrary.Models
{
    public class Skill : ISkill
    {
        public ushort Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte MaximumLevel { get; set; } = 1;
        public IEnumerable<ISkillLevel> SkillLevels { get; set; } = new List<ISkillLevel>();
    }
}
