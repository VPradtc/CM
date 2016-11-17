using System;

namespace CardMatch.Core.Models.Cards.Regular
{
    public class RegularCard : Card, IPairedCard
    {
        public override string Value { get; set; }

        public override bool IsPairTo(IPairedCard other)
        {
            return other.Value.CompareTo(Value) == 0;
        }
    }
}
