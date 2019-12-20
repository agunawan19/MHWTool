using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWLibrary.Models
{
    class Bones : IMaterial
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public byte Rarity { get; set; }
    }
}
