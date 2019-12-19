﻿using System;
using System.Collections.Generic;
using System.Text;
using MHWLibrary.Models.Interfaces;
using MHWLibraryNet.Models.Interfaces;

namespace MHWLibrary.Models
{
    public class Carving : ICarving
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public byte Rarity { get; set; }
        public MHWLibraryNet.Enums.Rank Rank { get; set; }
        public IMonster Monster { get; set; }
    }
}
