using System;
using System.Collections.Generic;
using System.Text;

namespace MHWLibrary.Models
{
    public class Monster
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public Size Size { get; set; }
        public List<Carving> Carvings { get; set; } = new List<Carving>();
    }
}
