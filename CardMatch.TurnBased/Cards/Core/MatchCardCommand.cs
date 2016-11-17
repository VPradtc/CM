using CardMatch.Core.GameFields.Cards.Commands;
using CardMatch.Core.Models.Cards;
using CardMatch.Core.Models.Cards.Regular;
using CardMatch.TurnBased.GameFields;
using System.Linq;

namespace CardMatch.TurnBased.Cards.Bonus
{
    public class MatchCardCommand<TCard> : ICardCommand<RegularCard, TurnBasedGameState<TCard>>
        where TCard: IPairedCard
    {
        public void Execute(RegularCard card, TurnBasedGameState<TCard> context)
        {
            var revealedCards = context.GetRevealedCards();

            var pairedCards = revealedCards.Where(revealedCard => card.IsPairTo(revealedCard.Card)).ToList();

            if (pairedCards.Count <= 1)
            {
                context.CloseRevealedCards();
                return;
            }

            context.CreateMatch(pairedCards);
        }
    }
}
