﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MHWLibrary.Models
{
    public interface ISkill
    {
        ushort Id { get; set; }
        string Name { get; set; }
        byte MaximumLevel { get; set; }
        IEnumerable<ISkillLevel> SkillLevels { get; set; }
    }
}
