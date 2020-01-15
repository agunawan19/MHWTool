using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MhwLibrary.Enumerations;

namespace MhwLibrary.Models
{
    public class Habitat : EntityBase, IHabitat
    {
        public HabitatEnum Id { get; set; }
        public string Name { get; set; }
    }
}