using System;
using System.Collections.Generic;
using System.Text;
using MHWLibrary.Enums;

namespace MHWLibrary.Models
{
    public interface IArmor
    {
        ushort Id { get; set; }
        ushort Defense { get; set; }
        string Name { get; set; }
        ArmorPiece Piece { get; }
        IEnumerable<IDecoration> DecorationSlots { get; set; }
        IResistance Resistance { get; set; }
        IEnumerable<ISkill> Skills { get; set; }
        byte Rarity { get; set; }
        IEnumerable<IMaterial> Materials { get; set; }
    }
}
