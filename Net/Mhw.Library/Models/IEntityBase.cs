﻿using System;

namespace Mhw.Library.Models
{
    public interface IEntityBase
    {
        DateTime CreatedUtcDate { get; set; }
        DateTime ModifiedDate { get; set; }

        IEntityBase SetModifiedDate(DateTime dateTime);
    }
}