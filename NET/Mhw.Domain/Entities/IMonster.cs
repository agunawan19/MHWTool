using System.Collections.Generic;

namespace Mhw.Domain.Entities
{
    public interface IMonster : IMonsterBase
    {
        IEnumerable<ICarving> Carvings { get; set; }
    }
}