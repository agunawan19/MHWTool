using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWLibrary.Models
{
    public interface ICarving : IMaterial
    {
        Enums.Rank Rank { get; set; }
        IMonsterBase Monster { get; set; }
    }
}
