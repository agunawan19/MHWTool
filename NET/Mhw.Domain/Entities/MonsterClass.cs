namespace Mhw.Domain.Entities
{
    public class MonsterClass : IMonsterClass
    {
        public Enumerations.MonsterClass Size { get; set; }
        public string Name { get; set; }
    }
}