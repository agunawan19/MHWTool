namespace Mhw.Library.Models
{
    public interface IArmorSetBonusSkill
    {
        short Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        ISkill Skill { get; set; }
    }
}