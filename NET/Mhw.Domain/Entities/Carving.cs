using Mhw.Domain.Enumerations;

namespace Mhw.Domain.Entities
{
    public class Carving : ICarving
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public byte Rarity { get; set; }
        public Rank Rank { get; set; }
        public IMonsterBase Monster { get; set; }

        public MaterialTypeEnum TypeId { get; set; }
        public MaterialType Type { get; set; }
    }
}