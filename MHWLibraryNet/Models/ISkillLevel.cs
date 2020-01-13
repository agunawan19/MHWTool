using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models
{
    public interface ISkillLevel
    {
        short Id { get; set; }
        byte Level { get; set; }
        string Description { get; set; }
        bool IsSecretLevel { get; set; }
    }
}