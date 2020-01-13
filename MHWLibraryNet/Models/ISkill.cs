using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MHWLibrary.Models
{
    public interface ISkill
    {
        short Id { get; set; }
        string Name { get; set; }
        byte MaximumLevel { get; set; }

        ICollection<SkillLevel> SkillLevels { get; set; }
    }
}