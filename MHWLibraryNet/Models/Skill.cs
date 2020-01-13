using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Models;

namespace MHWLibrary.Models
{
    public class Skill : EntityBase, ISkill
    {
        public short Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte MaximumLevel { get; set; } = 1;

        public ICollection<SkillLevel> SkillLevels { get; set; } = new List<SkillLevel>();
    }
}