using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWLibrary.Models
{
    public interface IMonsterAilmentWeakness
    {
        byte Poison { get; set; }
        byte Sleep { get; set; }
        byte Paralysis { get; set; }
        byte Blast { get; set; }
        byte Stun { get; set; }
    }
}