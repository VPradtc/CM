using CardMatch.Core.GameFields;
using CardMatch.Core.GameFields.CardPositions;
using CardMatch.Core.GameFields.Core;
using CardMatch.Core.Models.Cards;
using CardMatch.TurnBased.GameFields;
using System;
using System.Collections.Generic;

namespace CardMatch.TurnBased.Facade
{
    public class TurnBasedGameFieldFacade<TCard> : ITurnBasedGameFieldFacade<TCard>
        where TCard : ICard
    {
        private readonly IGameFieldFactory<TCard, TurnBasedGameState<TCard>> _gameFactory;

        private GameField<TCard, TurnBasedGameState<TCard>> _gameField;

        #region Singleton
        private static object __lock = new object();
        private static TurnBasedGameFieldFacade<TCard> __instance;

        public static TurnBasedGameFieldFacade<TCard> Instance
        {
            get
            {
                if (__instance == null)
                {
                    lock (__lock)
                    {
                        if (__instance == null)
                        {
                            //__instance = new TurnBasedGameFieldFacade<TCard>();
                        }
                    }
                }

                return __instance;
            }
        }
        #endregion

        public TurnBasedGameFieldFacade(IGameFieldFactory<TCard, TurnBasedGameState<TCard>> gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void NewGame()
        {
            _gameField.Context.OnCardMatched -= Context_OnCardMatched;
            _gameField.Context.OnCardsClosed -= Context_OnCardsClosed;

            _gameField = _gameFactory.Create();

            _gameField.Context.OnCardMatched += Context_OnCardMatched;
            _gameField.Context.OnCardsClosed += Context_OnCardsClosed;
        }

        void Context_OnCardsClosed(object sender, EventArgs e)
        {
            SafeInvoke(CardsClosing, e);
        }

        void Context_OnCardMatched(object sender, CardMatchEventArgs<TCard> e)
        {
            SafeInvoke(OnCardMatched, e);
        }

        public ICollection<ActiveCard<TCard>> GetRemainingCards()
        {
            return _gameField.Context.GetActiveCards();
        }

        public void PickCard(ActiveCard<TCard> card)
        {
            var oldStatus = card.Status;

            _gameField.PickCard(card);

            var newStatus = card.Status;

            if(oldStatus == Core.Models.Enums.CardStatus.Closed &&
                newStatus == Core.Models.Enums.CardStatus.Revealed)
            {
                SafeInvoke(OnCardRevealed, new CardRevelationEventArgs<TCard>()
                {
                    Card = card.Card
                });
            }
        }

        public int GetRemainingTurns()
        {
            return _gameField.Context.TurnsLeft;
        }

        public event EventHandler<EventArgs> CardsClosing;

        public event EventHandler<CardRevelationEventArgs<TCard>> OnCardRevealed;

        public event EventHandler<CardMatchEventArgs<TCard>> OnCardMatched;

        public event EventHandler<CardBonusEventArgs> OnBonusApplied;

        private void SafeInvoke<T>(EventHandler<T> targetEvent, T eventArgs)
        {
            if (targetEvent != null)
            {
                targetEvent.Invoke(this, eventArgs);
            }
        }
    }
}
