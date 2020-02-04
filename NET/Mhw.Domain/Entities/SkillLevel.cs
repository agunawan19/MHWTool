namespace Mhw.Domain.Entities
{
    public class SkillLevel : EntityBase, ISkillLevel
    {
        public short Id { get; set; }
        public byte Level { get; set; } = 1;
        public string Description { get; set; }
        public bool IsSecretLevel { get; set; } = false;

        public short SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}