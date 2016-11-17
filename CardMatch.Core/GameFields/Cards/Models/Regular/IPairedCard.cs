using System;

namespace CardMatch.Core.Models.Cards
{
    public interface IPairedCard
    {
        string Value { get; set; }

        bool IsPairTo(IPairedCard other);
    }
}
