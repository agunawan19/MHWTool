using System;

namespace MHWLibrary.Models
{
    public interface IEntityBase
    {
        DateTime ModifiedDate { get; set; }
    }
}