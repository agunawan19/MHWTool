using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Enumerations;

namespace MHWLibrary.Models
{
    internal interface IHabitat
    {
        HabitatEnum Id { get; set; }
        string Name { get; set; }
    }
}