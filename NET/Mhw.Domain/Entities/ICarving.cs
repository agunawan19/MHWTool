namespace Mhw.Domain.Entities
{
    public interface ICarving : IMaterial
    {
        Enumerations.Rank Rank { get; set; }
        IMonsterBase Monster { get; set; }
    }
}