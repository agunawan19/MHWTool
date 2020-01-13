﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models
{
    public class RankInfo : IRankInfo
    {
        public bool HasLowRank { get; set; }
        public bool HasHighRank { get; set; }
        public bool HasMasterRank { get; set; }
    }
}