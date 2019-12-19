using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Models;

namespace MHWLibrary.Models
{
    public class SkillLevel : ISkillLevel
    {
        public byte Level { get; set; } = 1;
        public string Description { get; set; }
        public bool IsExpansion { get; set; } = false;
    }
}
