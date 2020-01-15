using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MhwLibrary.Models;

namespace MhwLibrary.Models
{
    public class SkillLevel : EntityBase, ISkillLevel
    {
        public short Id { get; set; }
        public byte Level { get; set; } = 1;
        public string Description { get; set; }
        public bool IsSecretLevel { get; set; } = false;

        public short SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}