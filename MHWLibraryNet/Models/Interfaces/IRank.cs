namespace MHWLibrary.Models.Interfaces
{
    public interface IRank
    {
        bool HasLowRank { get; set; }
        bool HasHighRank { get; set; }
        bool HasMasterRank { get; set; }
    }
}