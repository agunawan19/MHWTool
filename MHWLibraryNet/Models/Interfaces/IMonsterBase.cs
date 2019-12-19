using System.Collections.Generic;

namespace MHWLibrary.Models.Interfaces
{
    public interface IMonsterBase
    {
        ushort Id { get; set; }
        string Name { get; set; }
        IMonsterSize Size { get; set; }
        IEnumerable<IRank> Ranks { get; set; }
    }
}