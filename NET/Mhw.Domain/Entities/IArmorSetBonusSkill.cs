namespace Mhw.Domain.Entities
{
    public interface IArmorSetBonusSkill
    {
        short Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        ISkill Skill { get; set; }
    }
}