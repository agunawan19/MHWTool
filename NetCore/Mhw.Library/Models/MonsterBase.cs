using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Models;

namespace MHWLibrary.Models
{
    public class MonsterBase : IMonsterBase
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public IMonsterSize Size { get; set; }
        public IEnumerable<IRank> Ranks { get; set; }
    }
}
