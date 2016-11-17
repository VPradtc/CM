using CardMatch.Core.GameFields.Cards.Commands;
using CardMatch.Core.Models.Cards;
using CardMatch.TurnBased.GameFields;

namespace CardMatch.TurnBased.Cards.Bonus
{
    public class ExtraTurnsBonusCardCommand<TCard> : ICardCommand<ExtraTurnsBonusCard, TurnBasedGameState<TCard>>
    {
        public void Execute(ExtraTurnsBonusCard card, TurnBasedGameState<TCard> context)
        {
            context.TurnsLeft += card.TurnCount;
        }
    }
}
