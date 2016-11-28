using CardMatch.Core.GameFields;
using CardMatch.Core.Models.Enums;
using System.Linq;

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

            var pairedCards = revealedCards.Where(revealedCard => this.IsPairTo(revealedCard)).ToList();

            if (pairedCards.Count <= 1)
            {
                context.CloseRevealedCards();
                return;
            }

            context.CreateMatch(pairedCards);
        }
    }
}
