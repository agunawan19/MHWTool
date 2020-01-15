namespace MhwLibrary.Models
{
    internal class MonsterAilmentWeakness : IMonsterAilmentWeakness
    {
        public byte Poison { get; set; }
        public byte Sleep { get; set; }
        public byte Paralysis { get; set; }
        public byte Blast { get; set; }
        public byte Stun { get; set; }
    }
}