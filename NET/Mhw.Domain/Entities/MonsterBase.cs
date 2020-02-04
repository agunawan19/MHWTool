using System.Collections.Generic;

namespace Mhw.Domain.Entities
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