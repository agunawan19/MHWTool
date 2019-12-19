using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Models.Interfaces;

namespace MHWLibraryNet.Models
{
    public class Material : IMaterial
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public byte Rarity { get; set; }
    }
}
