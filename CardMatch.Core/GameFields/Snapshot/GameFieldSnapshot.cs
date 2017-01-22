using System;
using System.Collections.Generic;

namespace CardMatch.Core.GameFields.Snapshot
{
    public class GameFieldSnapshot
    {
        public int TurnsLeft { get; set; }

        public List<CardSnapshot> Cards { get; set; }
    }
}
