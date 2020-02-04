namespace Mhw.Domain.Entities
{
    public interface IMonsterClass
    {
        Enumerations.MonsterClass Size { get; set; }
        string Name { get; set; }
    }
}