using System;

namespace Mhw.Domain.Entities
{
    public interface IEntityBase
    {
        DateTime CreatedUtcDate { get; set; }
        DateTime ModifiedDate { get; set; }

        IEntityBase SetModifiedDate(DateTime dateTime);
    }
}