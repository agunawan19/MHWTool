using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models.Interfaces
{
    public interface IArmor
    {
        ushort Defense { get; set; }
        IEnumerable<DecorationSlot> DecorationSlots { get; set; }
        IResistance Resistance { get; set; }
        IEnumerable<ISkill> Skills { get; set; }
    }
}
