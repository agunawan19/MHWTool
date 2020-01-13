using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Enumerations;

namespace MHWLibrary.Models
{
    public class Habitat : EntityBase, IHabitat
    {
        public HabitatEnum Id { get; set; }
        public string Name { get; set; }
    }
}