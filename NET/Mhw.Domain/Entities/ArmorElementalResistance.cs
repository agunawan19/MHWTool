﻿namespace Mhw.Domain.Entities
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