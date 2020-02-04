namespace Mhw.Domain.Entities
{
    internal interface IMonsterPhysiology
    {
        IMonsterElementalWeakness MonsterElementalWeakness { get; set; }
        IMonsterAilmentWeakness MonsterAilmentWeakness { get; set; }
    }
}