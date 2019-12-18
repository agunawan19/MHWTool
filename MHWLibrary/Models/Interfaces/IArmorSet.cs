namespace MHWLibrary.Models.Interfaces
{
    public interface IArmorSet
    {
        ushort Id { get; set; }
        string Name { get; set; }
        IArmorSetBonusSkill ArmorSetBonusSkill { get; set; }
    }
}