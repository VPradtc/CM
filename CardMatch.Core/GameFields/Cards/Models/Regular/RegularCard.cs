using System;

namespace CardMatch.Core.Models.Cards.Regular
{
    public class RegularCard : ICard
    {
        public string Value { get; set; }

        public bool IsPairTo(ICard other)
        {
            return other.Value.CompareTo(Value) == 0;
        }
    }
}
