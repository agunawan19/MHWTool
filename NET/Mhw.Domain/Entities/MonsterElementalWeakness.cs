namespace Mhw.Domain.Entities
{
    public class MonsterElementalWeakness : IMonsterElementalWeakness
    {
        public IMonsterElementalWeaknessDetail Fire { get; set; }
        public IMonsterElementalWeaknessDetail Water { get; set; }
        public IMonsterElementalWeaknessDetail Thunder { get; set; }
        public IMonsterElementalWeaknessDetail Ice { get; set; }
        public IMonsterElementalWeaknessDetail Dragon { get; set; }
    }
}