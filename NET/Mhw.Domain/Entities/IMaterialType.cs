using Mhw.Domain.Enumerations;

namespace Mhw.Domain.Entities
{
    internal interface IMaterialType
    {
        MaterialTypeEnum Id { get; set; }
        string Name { get; set; }
    }
}