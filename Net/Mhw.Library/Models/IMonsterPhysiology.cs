namespace Mhw.Library.Models
{
    internal interface IMonsterPhysiology
    {
        IMonsterElementalWeakness MonsterElementalWeakness { get; set; }
        IMonsterAilmentWeakness MonsterAilmentWeakness { get; set; }
    }
}