using System.Collections.Generic;

namespace Mhw.Library.Models
{
    public interface IMonster : IMonsterBase
    {
        IEnumerable<ICarving> Carvings { get; set; }
    }
}