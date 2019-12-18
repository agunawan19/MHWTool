using System;
using System.Collections.Generic;
using System.Text;
using MHWLibraryNet.Models;

namespace MHWLibrary.Models.Interfaces
{
    public class ArmorSet : IArmorSet
    {
        public ushort Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IArmorSetBonusSkill ArmorSetBonusSkill { get; set; } = new ArmorSetBonusSkill();
        public IList<IArmor> Armors { get; set; } = new List<IArmor>();
    }
}
