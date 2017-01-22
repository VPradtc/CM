using System;
using CardMatch.Core.Models.Enums;

namespace CardMatch.Core.GameFields.Snapshot
{
    public class CardSnapshot
    {
        public CardStatus Status { get; set; }
        public string Value { get; set; }
    }
}
