using System;
using System.Collections.Generic;
using System.Text;
using MHWLibrary.Models.Interfaces;
using MHWLibraryNet.Enums;

namespace MHWLibrary.Models
{
    public class Arm : IArmor
    {
        public ushort Defense { get; set; }
        public string Name { get; set; } = string.Empty;
        public ArmorPiece Piece { get; set; } = ArmorPiece.Arm;
        public IEnumerable<IDecoration> DecorationSlots { get; set; } = new List<IDecoration>();
        public IResistance Resistance { get; set; } = new Resistance();
        public IEnumerable<ISkill> Skills { get; set; } = new List<ISkill>();
    }
}
