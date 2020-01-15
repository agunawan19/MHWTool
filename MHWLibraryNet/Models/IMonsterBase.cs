﻿using System.Collections.Generic;

namespace MhwLibrary.Models
{
    public interface IMonsterBase
    {
        short Id { get; set; }
        string Name { get; set; }
        IMonsterSize Size { get; set; }
        IMonsterClass Class { get; set; }
        IEnumerable<IRankInfo> RankInfoCollection { get; set; }
    }
}