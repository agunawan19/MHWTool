using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWLibrary.Models
{
    internal interface IMonsterPhysiology
    {
        IMonsterElementalWeakness MonsterElementalWeakness { get; set; }
        IMonsterAilmentWeakness MonsterAilmentWeakness { get; set; }
    }
}