using System;
using Mhw.Domain.Enumerations;

namespace Mhw.Domain.Entities
{
    public class Habitat : EntityBase, IHabitat
    {
        public static Habitat CreateInstance()
        {
            return new Habitat();
        }

        public HabitatEnum Id { get; set; }
        public string Name { get; set; }

        public Habitat SetId(HabitatEnum id)
        {
            Id = id;
            return this;
        }

        public Habitat SetName(string name)
        {
            Name = name;
            return this;
        }
    }
}