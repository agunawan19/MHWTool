using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MhwLibrary.Enumerations;

namespace MhwLibrary.Models
{
    internal interface IHabitat
    {
        HabitatEnum Id { get; set; }
        string Name { get; set; }
    }
}