using System;
using System.Collections.Generic;
using System.Text;
using MHWLibrary.Models.Interfaces;
using MHWLibraryNet.Models.Interfaces;

namespace MHWLibrary.Models
{
    public class Monster : IMonster
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public IMonsterSize Size { get; set; }
        public IEnumerable<IRank> Ranks { get; set; }
        public IEnumerable<ICarving> Carvings { get; set; } = new List<ICarving>();
    }
}
