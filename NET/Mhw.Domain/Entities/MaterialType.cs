using System.Collections.Generic;
using Mhw.Domain.Enumerations;

namespace Mhw.Domain.Entities
{
    public class MaterialType : EntityBase, IMaterialType
    {
        public MaterialTypeEnum Id { get; set; }
        public string Name { get; set; }

        public ICollection<Material> Materials { get; set; }
    }
}