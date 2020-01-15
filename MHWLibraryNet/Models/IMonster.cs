using System.Collections.Generic;

namespace MhwLibrary.Models
{
    public interface IMonster : IMonsterBase
    {
        IEnumerable<ICarving> Carvings { get; set; }
    }
}