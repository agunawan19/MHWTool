﻿using System;

namespace Mhw.Library.Models
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual DateTime CreatedUtcDate { get; set; } = DateTime.UtcNow;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;

        public virtual IEntityBase SetModifiedDate(DateTime dateTime)
        {
            ModifiedDate = dateTime;
            return this;
        }
    }
}