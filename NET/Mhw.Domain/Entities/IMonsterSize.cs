namespace Mhw.Domain.Entities
{
    public interface IMonsterSize
    {
        Enumerations.MonsterSize Size { get; set; }
        string Name { get; set; }
    }
}