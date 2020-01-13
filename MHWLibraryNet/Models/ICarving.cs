using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Enumerations;

namespace MHWLibrary.Models
{
    public interface ICarving : IMaterial
    {
        Enumerations.Rank Rank { get; set; }
        IMonsterBase Monster { get; set; }
    }
}