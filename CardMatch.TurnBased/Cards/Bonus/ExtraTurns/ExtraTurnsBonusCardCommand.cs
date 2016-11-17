using CardMatch.Core.GameFields.Cards.Commands;
using CardMatch.Core.Models.Cards;
using CardMatch.TurnBased.GameFields;

namespace CardMatch.TurnBased.Cards.Bonus
{
    public class ExtraTurnsBonusCardCommand : ICardCommand<ExtraTurnsBonusCard, TurnBasedGameState>
    {
        public void Execute(ExtraTurnsBonusCard card, TurnBasedGameState context)
        {
            context.TurnsLeft += card.TurnCount;
        }
    }
}
