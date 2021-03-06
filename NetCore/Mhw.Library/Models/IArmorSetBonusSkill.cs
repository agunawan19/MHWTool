﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models
{
    public interface IArmorSetBonusSkill
    {
        ushort Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        ISkill Skill { get; set; }
    }
}
