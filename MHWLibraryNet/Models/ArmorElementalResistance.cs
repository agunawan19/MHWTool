using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models
{
    public class ArmorElementalResistance : IArmorElementalResistance
    {
        public sbyte Fire { get; set; }
        public sbyte Water { get; set; }
        public sbyte Thunder { get; set; }
        public sbyte Ice { get; set; }
        public sbyte Dragon { get; set; }
    }
}