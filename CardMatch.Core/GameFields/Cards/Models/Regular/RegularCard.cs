using CardMatch.Core.GameFields;
using CardMatch.Core.Models.Enums;
using System.Linq;
using System;
using CardMatch.Core.GameFields.Snapshot;

namespace CardMatch.Core.Models.Cards.Regular
{
    public class RegularCard : ICard
    {
        public CardStatus Status { get; set; }

        public string Value { get; set; }

        public bool IsPairTo(ICard other)
        {
            return other.Value.CompareTo(Value) == 0;
        }

        public void Execute(GameField context)
        {
            var revealedCards = context.GetRevealedCards();

            if (revealedCards.Count() <= 1)
            {
                return;
            }

            var pairedCards = revealedCards.Where(revealedCard => this.IsPairTo(revealedCard)).ToList();

            if (pairedCards.Count <= 1)
            {
                return;
            }

            if (pairedCards.Count > 2)
            {
                throw new ArgumentException("Invalid gamefield configuration.");
            }

            var pair = new Tuple<ICard, ICard>(pairedCards.First(), pairedCards.Last());

            context.CreateMatch(pair);
        }

        public ICard Clone()
        {
            return new RegularCard()
            {
                Status = Status,
                Value = Value,
            };
        }

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
