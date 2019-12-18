using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models.Interfaces
{
    public interface ISkill
    {
        ushort Id { get; set; }
        byte MaximumLevel { get; set; }
        List<ISkillLevel> SkillLevels { get; set; }
    }
}
