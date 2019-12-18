using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models
{
    public class Carving
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public byte Rarity { get; set; }
        public Rank Rank { get; set; }
    }
}
