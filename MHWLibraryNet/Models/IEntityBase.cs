using System;

namespace MhwLibrary.Models
{
    public interface IEntityBase
    {
        DateTime ModifiedDate { get; set; }
    }
}