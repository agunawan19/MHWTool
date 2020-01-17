using System.Collections.Generic;

namespace MHWLibrary.Models
{
    public interface IMonster : IMonsterBase
    {
        IEnumerable<ICarving> Carvings { get; set; }
    }
}