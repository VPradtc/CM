using CardMatch.Core.GameFields.Cards.Commands;
using CardMatch.Core.Models.Cards;
using CardMatch.TurnBased.GameFields;

namespace CardMatch.TurnBased.Cards.Bonus
{
    public class RemovePairsBonusCardCommand : ICardCommand<RemovePairsBonusCard, TurnBasedGameState>
    {
        public void Execute(RemovePairsBonusCard card, TurnBasedGameState context)
        {

        }
    }
}
