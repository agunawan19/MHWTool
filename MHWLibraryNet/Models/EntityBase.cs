using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWLibrary.Models
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual DateTime ModifiedDate { get; set; }
    }
}