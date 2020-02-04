using Mhw.Domain.Enumerations;

namespace Mhw.Domain.Entities
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