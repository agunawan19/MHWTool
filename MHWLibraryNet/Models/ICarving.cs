using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MhwLibrary.Enumerations;

namespace MhwLibrary.Models
{
    public interface ICarving : IMaterial
    {
        Enumerations.Rank Rank { get; set; }
        IMonsterBase Monster { get; set; }
    }
}