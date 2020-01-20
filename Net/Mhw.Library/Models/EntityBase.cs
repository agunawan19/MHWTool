using System;

namespace Mhw.Library.Models
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual DateTime CreatedUtcDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual IEntityBase SetModifiedDate(DateTime dateTime)
        {
            ModifiedDate = dateTime;
            return this;
        }
    }
}