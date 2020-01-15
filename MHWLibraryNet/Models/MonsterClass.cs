using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MhwLibrary.Models
{
    public class MonsterClass : IMonsterClass
    {
        public Enumerations.MonsterClass Size { get; set; }
        public string Name { get; set; }
    }
}