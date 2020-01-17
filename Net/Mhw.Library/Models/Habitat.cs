using Mhw.Library.Enumerations;

namespace Mhw.Library.Models
{
    public class Habitat : EntityBase, IHabitat
    {
        public static Habitat CreateInstance()
        {
            return new Habitat();
        }

        public HabitatEnum Id { get; set; }
        public string Name { get; set; }

        //public Habitat SetName(string name)
        //{
        //    Name = name;
        //    return this;
        //}
    }
}