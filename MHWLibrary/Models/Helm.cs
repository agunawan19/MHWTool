using System;
using System.Collections.Generic;
using System.Text;
using MHWLibrary.Models.Interfaces;

namespace MHWLibrary.Models
{
    public class Helm : IArmor
    {
        public ushort Defense { get; set; }
        public IEnumerable<DecorationSlot> DecorationSlots { get; set; }
        public IResistance Resistance { get; set; }
        public IArmorSetBonusSkill ArmorSetBonusSkill { get; set; }
        public IEnumerable<ISkill> Skills { get; set; }
    }
}
