using Mhw.Library.Enumerations;

namespace Mhw.Library.Models
{
    internal interface IHabitat
    {
        HabitatEnum Id { get; set; }
        string Name { get; set; }
    }
}