using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MhwLibrary.Models
{
    public interface IMonsterElementalWeaknessDetail
    {
        byte Default { get; set; }
        byte? Conditional { get; set; }
        string ConditionalNote { get; set; }
    }
}