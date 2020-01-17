using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models
{
    public interface IMaterial
    {
        ushort Id { get; set; }
        string Name { get; set; }
        byte Rarity { get; set; }
    }
}
