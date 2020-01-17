using Mhw.Library.Enumerations;

namespace Mhw.Library.Models
{
    public interface IMaterial
    {
        short Id { get; set; }
        string Name { get; set; }
        byte Rarity { get; set; }

        MaterialTypeEnum TypeId { get; set; }
        MaterialType Type { get; set; }
    }
}