using System;
using System.Collections.Generic;
using System.Text;
using MHWLibrary.Models.Interfaces;

namespace MHWLibrary.Models
{
    public class MonsterSize : IMonsterSize
    {
        public MHWLibraryNet.Enums.MonsterSize Size { get; set; }
    }
}
