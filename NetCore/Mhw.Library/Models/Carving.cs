using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models
{
    public class Carving : ICarving
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public byte Rarity { get; set; }
        public Enums.Rank Rank { get; set; }
        public IMonsterBase Monster { get; set; }
    }
}
