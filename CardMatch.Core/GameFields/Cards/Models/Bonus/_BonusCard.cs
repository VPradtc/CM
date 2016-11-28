using System;
using CardMatch.Core.GameFields;
using CardMatch.Core.Models.Enums;

namespace CardMatch.Core.Models.Cards
{
    public abstract class BonusCard : ICard
    {
        public abstract string Value { get; }

        public CardStatus Status { get; set; }

        public abstract void Execute(GameField context);

        public bool IsPairTo(ICard other)
        {
            return false;
        }

    }
}
