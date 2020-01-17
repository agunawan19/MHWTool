namespace Mhw.Library.Models
{
    public interface IMonsterElementalWeakness
    {
        IMonsterElementalWeaknessDetail Fire { get; set; }
        IMonsterElementalWeaknessDetail Water { get; set; }
        IMonsterElementalWeaknessDetail Thunder { get; set; }
        IMonsterElementalWeaknessDetail Ice { get; set; }
        IMonsterElementalWeaknessDetail Dragon { get; set; }
    }
}