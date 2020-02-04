namespace Mhw.Domain.Entities
{
    public class RankInfo : IRankInfo
    {
        public bool HasLowRank { get; set; }
        public bool HasHighRank { get; set; }
        public bool HasMasterRank { get; set; }
    }
}
