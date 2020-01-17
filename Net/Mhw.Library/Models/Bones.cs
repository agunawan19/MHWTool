using Mhw.Library.Enumerations;

namespace Mhw.Library.Models
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