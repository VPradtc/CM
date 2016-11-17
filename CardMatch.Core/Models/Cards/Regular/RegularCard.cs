using System;

namespace CardMatch.Core.Models.Cards.Regular
{
    public class RegularCard<TValue> : Card, IPairedCard<TValue>
        where TValue : IComparable<TValue>
    {
        public TValue Value { get; set; }

        public bool IsPairTo(IPairedCard<TValue> other)
        {
            return other.Value.CompareTo(Value) == 0;
        }
    }
}
