using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLibrary.Models
{
    public class MonsterSize : IMonsterSize
    {
        public Enumerations.MonsterSize Size { get; set; }
        public string Name { get; set; }
    }
}