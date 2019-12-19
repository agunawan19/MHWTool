using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models
{
    public class ArmorSet : IArmorSet
    {
        public ushort Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IArmorSetBonusSkill ArmorSetBonusSkill { get; set; } = new ArmorSetBonusSkill();
        public IEnumerable<IArmor> Armors { get; set; } = new List<IArmor>();
    }
}
