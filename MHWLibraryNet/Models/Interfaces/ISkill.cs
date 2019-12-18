using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models.Interfaces
{
    public interface ISkill
    {
        ushort Id { get; set; }
        string Name { get; set; }
        byte MaximumLevel { get; set; }
        IList<ISkillLevel> SkillLevels { get; set; }
    }
}
