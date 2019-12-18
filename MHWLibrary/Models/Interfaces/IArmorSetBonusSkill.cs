﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models.Interfaces
{
    public interface IArmorSetBonusSkill
    {
        string Name { get; set; }
        string Description { get; set; }
        ISkill Skill { get; set; }
    }
}
