using System.Collections.Generic;

namespace Mhw.Library.Models
{
    public class Monster : IMonster
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public IMonsterSize Size { get; set; }
        public IMonsterClass Class { get; set; }
        public IEnumerable<IRankInfo> RankInfoCollection { get; set; }
        public IEnumerable<ICarving> Carvings { get; set; } = new List<ICarving>();
    }
}