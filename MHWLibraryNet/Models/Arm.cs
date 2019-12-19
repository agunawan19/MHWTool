using System;
using System.Collections.Generic;
using System.Text;
using MHWLibrary.Models.Interfaces;
using MHWLibraryNet.Enums;
using MHWLibraryNet.Models;

namespace MHWLibrary.Models
{
    public class Arm : ArmorBase
    {
        public override ArmorPiece Piece => ArmorPiece.Arms;
    }
}
