using CardMatch.Core.GameFields;
using CardMatch.Core.GameFields.CardPositions;
using CardMatch.Core.Models.Cards;
using CardMatch.Core.Models.Enums;
using CardMatch.Core.GameFields.CardPositions.States;
using System.Linq;
using System;
using System.Collections.Generic;
using CardMatch.TurnBased.Facade;

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

        private void SafeInvoke<T>(EventHandler<T> targetEvent, T eventArgs)
        {
            if (targetEvent != null)
            {
                targetEvent.Invoke(this, eventArgs);
            }
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

            SafeInvoke<EventArgs>(OnCardsClosed, new EventArgs());
        }

        public void CreateMatch(List<ActiveCard<TCard>> pairedCards)
        {
            foreach (var card in pairedCards)
            {
                if (!_gameField.Cards.Contains(card))
                {
                    throw new InvalidOperationException();
                }

                card.State = new RemovedActiveCardState<TCard>(card);
            }

            SafeInvoke(OnCardMatched, new CardMatchEventArgs<TCard>()
            {
                CardPair = new Tuple<TCard, TCard>(pairedCards.First().Card, pairedCards.Last().Card)
            });
        }

        public event EventHandler<EventArgs> OnCardsClosed;
        public event EventHandler<CardMatchEventArgs<TCard>> OnCardMatched;
    }
}
