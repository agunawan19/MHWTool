namespace Mhw.Domain.Entities
{
    public interface ISkillLevel
    {
        short Id { get; set; }
        byte Level { get; set; }
        string Description { get; set; }
        bool IsSecretLevel { get; set; }
    }
}