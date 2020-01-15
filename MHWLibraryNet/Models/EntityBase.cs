using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MhwLibrary.Models
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual DateTime ModifiedDate { get; set; }
    }
}