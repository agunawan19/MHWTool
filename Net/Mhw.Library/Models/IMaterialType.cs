using Mhw.Library.Enumerations;

namespace Mhw.Library.Models
{
    internal interface IMaterialType
    {
        MaterialTypeEnum Id { get; set; }
        string Name { get; set; }
    }
}