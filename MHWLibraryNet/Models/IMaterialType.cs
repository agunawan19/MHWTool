using MhwLibrary.Enumerations;

namespace MhwLibrary.Models
{
    internal interface IMaterialType
    {
        MaterialTypeEnum Id { get; set; }
        string Name { get; set; }
    }
}