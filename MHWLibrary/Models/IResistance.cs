using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models
{
    public interface IResistance
    {
        sbyte Fire { get; set; }
        sbyte Water { get; set; }
        sbyte Thunder { get; set; }
        sbyte Ice { get; set; }
        sbyte Dragon { get; set; }
    }
}
