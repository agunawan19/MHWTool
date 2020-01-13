using System.Collections.Generic;

namespace MHWLibrary.Models
{
    public interface IArmorSet
    {
        short Id { get; set; }
        string Name { get; set; }
        IEnumerable<IArmor> Armors { get; set; }
        IArmorSetBonusSkill ArmorSetBonusSkill { get; set; }
    }
}