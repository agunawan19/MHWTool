using System.Collections.Generic;

namespace MhwLibrary.Models
{
    public interface IArmorSet
    {
        short Id { get; set; }
        string Name { get; set; }
        IEnumerable<IArmor> Armors { get; set; }
        IArmorSetBonusSkill ArmorSetBonusSkill { get; set; }
    }
}