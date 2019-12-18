using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Models.Interfaces;

namespace MHWLibraryNet.Models
{
    public class ArmorSetBonusSkill : IArmorSetBonusSkill
    {
        public ushort Id { get; set; }
        public string Name { get; set; } = "No Bonus";
        public string Description { get; set; } = string.Empty;
        public ISkill Skill { get; set; } = new Skill();
    }
}
