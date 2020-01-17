﻿using System;

namespace Mhw.Library.Models
{
    public interface IEntityBase
    {
        DateTime ModifiedDate { get; set; }

        IEntityBase SetModifiedDate(DateTime dateTime);
    }
}