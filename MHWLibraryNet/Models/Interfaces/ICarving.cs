using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Models.Interfaces;
using MHWLibraryNet.Enums;

namespace MHWLibraryNet.Models.Interfaces
{
    public interface ICarving : IMaterial
    {
        Rank Rank { get; set; }
        IMonster Monster { get; set; }
    }
}
