using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Models;
using MHWLibrary.Enumerations;

namespace MHWLibrary
{
    public class ArmorFactory
    {
        private static ArmorFactory _instance;

        private ArmorFactory() { }

        public static ArmorFactory Instance =>
            _instance ?? (_instance = new ArmorFactory());

        public IArmor Build(ArmorPiece armorPiece, string name)
        {
            IArmor armor = null;

            switch (armorPiece)
            {
                case ArmorPiece.Helm:
                    armor = new Head { Name = name };
                    break;
                case ArmorPiece.Chest:
                    armor = new Chest { Name = name };
                    break;
                case ArmorPiece.Arms:
                    armor = new Arm { Name = name };
                    break;
                case ArmorPiece.Waist:
                    armor = new Waist { Name = name };
                    break;
                case ArmorPiece.Leg:
                    armor = new Leg { Name = name };
                    break;
            }

            return armor;
        }

        public IEnumerable<IArmor> Build(IEnumerable<(ArmorPiece Piece, string Name)> armorPieces) =>
            armorPieces.Select(armorPiece => Build(armorPiece.Piece, armorPiece.Name));
    }
}
