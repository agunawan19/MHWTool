namespace Mhw.Domain.Entities
{
    public class MonsterSize : IMonsterSize
    {
        public Enumerations.MonsterSize Size { get; set; }
        public string Name { get; set; }
    }
}