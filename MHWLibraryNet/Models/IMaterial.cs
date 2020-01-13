using System;
using System.Collections.Generic;
using System.Text;
using MHWLibrary.Enumerations;

namespace MHWLibrary.Models
{
    public interface IMaterial
    {
        short Id { get; set; }
        string Name { get; set; }
        byte Rarity { get; set; }

        MaterialTypeEnum TypeId { get; set; }
        MaterialType Type { get; set; }
    }
}