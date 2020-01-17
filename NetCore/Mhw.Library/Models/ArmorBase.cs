using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Enums;
using MHWLibrary.Models;

namespace MHWLibrary.Models
{
    public abstract class ArmorBase : IArmor
    {
        public ushort Id { get; set; }
        public ushort Defense { get; set; }
        public string Name { get; set; } = string.Empty;
        public abstract ArmorPiece Piece { get; }
        public IEnumerable<IDecoration> DecorationSlots { get; set; } = new List<IDecoration>();
        public IResistance Resistance { get; set; }
        public IEnumerable<ISkill> Skills { get; set; } = new List<ISkill>();
        public ushort Rarity { get; set; }
        public IEnumerable<IMaterial> Materials { get; set; } = new List<IMaterial>();
    }
}