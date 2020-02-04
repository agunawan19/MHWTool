namespace Mhw.Domain.Entities
{
    internal class MonsterElementalWeaknessDetail : IMonsterElementalWeaknessDetail
    {
        public byte Default { get; set; }
        public byte? Conditional { get; set; }
        public string ConditionalNote { get; set; }
    }
}