using System.Collections.Generic;

namespace Mhw.Library.Models
{
    public class ArmorSet : IArmorSet
    {
        public short Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IArmorSetBonusSkill ArmorSetBonusSkill { get; set; } = new ArmorSetBonusSkill();
        public IEnumerable<IArmor> Armors { get; set; } = new List<IArmor>();
    }
}