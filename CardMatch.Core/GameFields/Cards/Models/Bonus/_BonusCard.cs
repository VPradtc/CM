using System;
using CardMatch.Core.GameFields;
using CardMatch.Core.Models.Enums;
using CardMatch.Core.GameFields.Snapshot;

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

        public ICard Clone()
        {
            var clone = this.CloneOwnProperties();

            clone.Status = Status;

            return clone;
        }

        protected abstract ICard CloneOwnProperties();

        public CardSnapshot CreateSnapshot()
        {
            return new CardSnapshot
            {
                Status = Status,
                Value = Value,
            };
        }
    }
}
