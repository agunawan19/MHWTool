namespace Mhw.Domain.Entities
{
    public class MonsterPhysiology : IMonsterPhysiology
    {
        public IMonsterElementalWeakness MonsterElementalWeakness { get; set; }
        public IMonsterAilmentWeakness MonsterAilmentWeakness { get; set; }
    }
}