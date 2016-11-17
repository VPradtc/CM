using CardMatch.Core.GameFields.Cards.Commands;
using CardMatch.Core.Models.Cards;
using CardMatch.TurnBased.GameFields;

namespace CardMatch.TurnBased.Cards.Bonus
{
    public class RemovePairsBonusCardCommand<TCard> : ICardCommand<RemovePairsBonusCard, TurnBasedGameState<TCard>>
        where TCard : IPairedCard
    {
        public void Execute(RemovePairsBonusCard card, TurnBasedGameState<TCard> context)
        {

        }
    }
}
