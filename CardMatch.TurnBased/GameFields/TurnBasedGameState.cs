using CardMatch.Core.GameFields;
using CardMatch.Core.GameFields.CardPositions;
using CardMatch.Core.Models.Cards;
using CardMatch.Core.Models.Enums;
using System.Linq;
using CardMatch.Core.GameFields.CardPositions.States;

namespace CardMatch.TurnBased.GameFields
{
    public class TurnBasedGameState<TCard>
        where TCard : IPairedCard
    {
        private GameField<TCard, TurnBasedGameState<TCard>> _gameField;

        public int TurnsLeft { get; set; }

        public TurnBasedGameState(GameField<TCard, TurnBasedGameState<TCard>> gamefield)
        {
            _gameField = gamefield;
        }

        public ActiveCard<TCard>[] GetActiveCards()
        {
            return _gameField.Cards.Where(card => card.Status != CardStatus.Removed).ToArray();
        }

        public ActiveCard<TCard>[] GetRevealedCards()
        {
            var activeCards = GetActiveCards();
            var revealedCards = activeCards.Where(card => card.Status == CardStatus.Revealed);

            return revealedCards.ToArray();
        }

        public void CloseRevealedCards()
        {
            var cards = GetRevealedCards();

            foreach (var card in cards)
            {
                card.State = new ClosedActiveCardState<TCard>(card);
            }
        }

        public void CreateMatch(System.Collections.Generic.List<ActiveCard<TCard>> pairedCards)
        {
            throw new System.NotImplementedException();
        }
    }
}
