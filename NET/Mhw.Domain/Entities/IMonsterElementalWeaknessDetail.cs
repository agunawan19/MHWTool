namespace Mhw.Domain.Entities
{
    public interface IMonsterElementalWeaknessDetail
    {
        byte Default { get; set; }
        byte? Conditional { get; set; }
        string ConditionalNote { get; set; }
    }
}