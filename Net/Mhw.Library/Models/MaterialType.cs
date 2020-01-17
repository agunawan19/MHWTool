using System.Collections.Generic;
using Mhw.Library.Enumerations;

namespace Mhw.Library.Models
{
    public class MaterialType : EntityBase, IMaterialType
    {
        public MaterialTypeEnum Id { get; set; }
        public string Name { get; set; }

        public ICollection<Material> Materials { get; set; }
    }
}