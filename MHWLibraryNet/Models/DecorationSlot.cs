using System;
using System.Collections.Generic;
using System.Text;
using MHWLibrary.Models.Interfaces;

namespace MHWLibrary.Models
{
    public class DecorationSlot : IDecoration
    {
        public byte Level { get; set; } = 1;
    }
}
