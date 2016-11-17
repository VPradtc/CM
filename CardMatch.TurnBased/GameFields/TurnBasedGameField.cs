using CardMatch.Core.GameFields;
using CardMatch.Core.Models.Cards;

namespace CardMatch.TurnBased.GameFields
{
    public class TurnBasedGameField<TCard> : GameField<TCard, TurnBasedGameState<TCard>>
        where TCard : ICard
    {
    }
}
