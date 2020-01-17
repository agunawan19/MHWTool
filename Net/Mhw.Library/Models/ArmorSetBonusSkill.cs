namespace Mhw.Library.Models
{
    public class ArmorSetBonusSkill : IArmorSetBonusSkill
    {
        public short Id { get; set; }
        public string Name { get; set; } = "No Bonus";
        public string Description { get; set; } = string.Empty;
        public ISkill Skill { get; set; } = new Skill();
    }
}