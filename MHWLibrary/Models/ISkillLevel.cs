using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models
{
    public interface ISkillLevel
    {
        byte Level { get; set; }
        string Description { get; set; }
        bool IsExpansion { get; set; }
    }
}
