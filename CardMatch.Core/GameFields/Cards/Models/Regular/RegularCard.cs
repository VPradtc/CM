using System;

namespace CardMatch.Core.Models.Cards.Regular
{
    public class RegularCard : IPairedCard
    {
        public string Value { get; set; }

        public bool IsPairTo(IPairedCard other)
        {
            return other.Value.CompareTo(Value) == 0;
        }
    }
}
