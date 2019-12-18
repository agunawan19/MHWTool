using System;
using System.Collections.Generic;
using System.Text;
using MHWLibrary.Models.Interfaces;

namespace MHWLibrary.Models
{
    public class Rank : IRank
    {
        public byte Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
