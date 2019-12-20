namespace MHWLibrary.Models
{
    public interface IRankInfo
    {
        bool HasLowRank { get; set; }
        bool HasHighRank { get; set; }
        bool HasMasterRank { get; set; }
    }
}