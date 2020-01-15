using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MhwLibrary.Models;

namespace MhwLibrary.Models
{
    public class MonsterBase : IMonsterBase
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public IMonsterSize Size { get; set; }
        public IMonsterClass Class { get; set; }
        public IEnumerable<IRankInfo> RankInfoCollection { get; set; }
    }
}