using Mhw.Domain.Enumerations;

namespace Mhw.Domain.Entities
{
    internal class Bones : IMaterial
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public byte Rarity { get; set; }

        public MaterialTypeEnum TypeId { get; set; }
        public MaterialType Type { get; set; }
    }
}