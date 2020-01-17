namespace MHWLibrary.Models
{
    public interface IRank
    {
        bool HasLowRank { get; set; }
        bool HasHighRank { get; set; }
        bool HasMasterRank { get; set; }
    }
}