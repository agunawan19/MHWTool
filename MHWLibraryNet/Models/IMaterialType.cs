using MHWLibrary.Enumerations;

namespace MHWLibrary.Models
{
    internal interface IMaterialType
    {
        MaterialTypeEnum Id { get; set; }
        string Name { get; set; }
    }
}