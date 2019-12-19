using System;
using System.Collections.Generic;
using System.Text;
using MHWLibrary.Models.Interfaces;

namespace MHWLibrary.Models
{
    public class Rank : IRank
    {
        public bool HasLowRank { get; set; }
        public bool HasHighRank { get; set; }
        public bool HasMasterRank { get; set; }
    }
}
