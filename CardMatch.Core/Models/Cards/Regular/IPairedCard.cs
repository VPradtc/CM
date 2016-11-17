using System;

namespace CardMatch.Core.Models.Cards
{
    public interface IPairedCard<TValue>
        where TValue : IComparable<TValue>
    {
        TValue Value { get; set; }

        bool IsPairTo(IPairedCard<TValue> other);
    }
}
