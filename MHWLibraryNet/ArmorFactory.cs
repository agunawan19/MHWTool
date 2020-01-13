using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Models;
using MHWLibrary.Enumerations;

namespace MHWLibrary
{
    public sealed class ArmorFactory
    {
        private static ArmorFactory _instance;

        private ArmorFactory()
        {
        }

        public static ArmorFactory Instance =>
            _instance ?? (_instance = new ArmorFactory());

        public IArmor Build(ArmorPiece armorPiece, string name)
        {
            switch (armorPiece)
            {
                case ArmorPiece.Head:
                    return new Head { Name = name };

                case ArmorPiece.Chest:
                    return new Chest { Name = name };

                case ArmorPiece.Arms:
                    return new Arm { Name = name };

                case ArmorPiece.Waist:
                    return new Waist { Name = name };

                case ArmorPiece.Leg:
                    return new Leg { Name = name };

                default:
                    throw new ArgumentOutOfRangeException(nameof(armorPiece), armorPiece, null);
            }
        }

        public IEnumerable<IArmor> Build(IEnumerable<(ArmorPiece Piece, string Name)> armorPieces) =>
            armorPieces.Select(armorPiece => Build(armorPiece.Piece, armorPiece.Name));
    }
}