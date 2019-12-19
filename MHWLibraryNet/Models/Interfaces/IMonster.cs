using System.Collections.Generic;
using MHWLibraryNet.Models.Interfaces;

namespace MHWLibrary.Models.Interfaces
{
    public interface IMonster : IMonsterBase
    {
        IEnumerable<ICarving> Carvings { get; set; }
    }
}