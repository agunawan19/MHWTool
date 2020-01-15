﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MhwLibrary.Enumerations;
using MhwLibrary.Models;

namespace MhwLibrary.Models
{
    public abstract class ArmorBase : IArmor
    {
        public short Id { get; set; }
        public short Defense { get; set; }
        public string Name { get; set; } = string.Empty;
        public abstract ArmorPiece Piece { get; }
        public IEnumerable<IDecoration> DecorationSlots { get; set; } = new List<IDecoration>();
        public IArmorElementalResistance ArmorElementalResistance { get; set; } = new ArmorElementalResistance();
        public IEnumerable<ISkill> Skills { get; set; } = new List<ISkill>();
        public byte Rarity { get; set; }
        public IEnumerable<IMaterial> Materials { get; set; } = new List<IMaterial>();
    }
}