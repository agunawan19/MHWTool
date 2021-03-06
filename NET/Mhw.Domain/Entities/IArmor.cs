﻿using System.Collections.Generic;
using Mhw.Domain.Enumerations;

namespace Mhw.Domain.Entities
{
    public interface IArmor
    {
        short Id { get; set; }
        short Defense { get; set; }
        string Name { get; set; }
        ArmorPiece Piece { get; }
        IEnumerable<IDecoration> DecorationSlots { get; set; }
        IArmorElementalResistance ArmorElementalResistance { get; set; }
        IEnumerable<ISkill> Skills { get; set; }
        byte Rarity { get; set; }
        IEnumerable<IMaterial> Materials { get; set; }
    }
}