﻿using System.Collections.Generic;

namespace MHWLibrary.Models.Interfaces
{
    public interface IArmorSet
    {
        ushort Id { get; set; }
        string Name { get; set; }
        IEnumerable<IArmor> Armors { get; set; }
        IArmorSetBonusSkill ArmorSetBonusSkill { get; set; }
    }
}