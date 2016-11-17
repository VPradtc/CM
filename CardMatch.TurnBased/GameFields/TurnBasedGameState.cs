using CardMatch.Core.GameFields;
using CardMatch.Core.GameFields.CardPositions;
using CardMatch.Core.Models.Enums;
using System.Linq;

namespace CardMatch.TurnBased.GameFields
{
    public class TurnBasedGameState<TCard>
    {
        private GameField<TCard, TurnBasedGameState<TCard>> _gameField;

        public TurnBasedGameState(GameField<TCard, TurnBasedGameState<TCard>> gamefield)
        {
            _gameField = gamefield;
        }

        public int TurnsLeft { get; set; }

        public ActiveCard<TCard>[] GetActiveCards()
        {
            return _gameField.Cards.Where(card => card.Status != CardStatus.Removed).ToArray();
        }
    }
}
