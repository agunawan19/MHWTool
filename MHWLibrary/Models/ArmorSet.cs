using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models.Interfaces
{
    public class ArmorSet : IArmorSet
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public IArmorSetBonusSkill ArmorSetBonusSkill { get; set; }
        public IEnumerable<IArmor> Armors { get; set; } = new List<IArmor>();
    }
}
