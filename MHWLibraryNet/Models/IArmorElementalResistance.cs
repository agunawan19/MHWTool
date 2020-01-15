using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLibrary.Models
{
    public interface IArmorElementalResistance
    {
        sbyte Fire { get; set; }
        sbyte Water { get; set; }
        sbyte Thunder { get; set; }
        sbyte Ice { get; set; }
        sbyte Dragon { get; set; }
    }
}