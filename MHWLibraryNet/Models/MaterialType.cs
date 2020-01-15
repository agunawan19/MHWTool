using System.Collections.Generic;
using MhwLibrary.Enumerations;

namespace MhwLibrary.Models
{
    public class MaterialType : EntityBase, IMaterialType
    {
        public MaterialTypeEnum Id { get; set; }
        public string Name { get; set; }

        public ICollection<Material> Materials { get; set; }
    }
}