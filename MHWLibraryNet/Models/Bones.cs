using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MhwLibrary.Enumerations;

namespace MhwLibrary.Models
{
    internal class Bones : IMaterial
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public byte Rarity { get; set; }

        public MaterialTypeEnum TypeId { get; set; }
        public MaterialType Type { get; set; }
    }
}