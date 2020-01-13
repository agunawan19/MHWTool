using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWLibrary.Models
{
    public interface IMonsterElementalWeakness
    {
        IMonsterElementalWeaknessDetail Fire { get; set; }
        IMonsterElementalWeaknessDetail Water { get; set; }
        IMonsterElementalWeaknessDetail Thunder { get; set; }
        IMonsterElementalWeaknessDetail Ice { get; set; }
        IMonsterElementalWeaknessDetail Dragon { get; set; }
    }
}