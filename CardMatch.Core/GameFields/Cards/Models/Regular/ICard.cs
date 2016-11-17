using System;

namespace CardMatch.Core.Models.Cards
{
    public interface ICard
    {
        string Value { get; set; }

        bool IsPairTo(ICard other);
    }
}
