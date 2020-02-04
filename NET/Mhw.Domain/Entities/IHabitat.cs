using Mhw.Domain.Enumerations;

namespace Mhw.Domain.Entities
{
    internal interface IHabitat
    {
        HabitatEnum Id { get; set; }
        string Name { get; set; }
    }
}