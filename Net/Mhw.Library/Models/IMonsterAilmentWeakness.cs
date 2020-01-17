namespace Mhw.Library.Models
{
    public interface IMonsterAilmentWeakness
    {
        byte Poison { get; set; }
        byte Sleep { get; set; }
        byte Paralysis { get; set; }
        byte Blast { get; set; }
        byte Stun { get; set; }
    }
}