using CardMatch.Core.GameFields;
using CardMatch.Core.GameFields.Core;
using CardMatch.TurnBased.GameFields;
using System;
using System.Collections.Generic;

namespace CardMatch.TurnBased.Facade
{
    public class TurnBasedGameFieldFacade<TCard> : ITurnBasedGameFieldFacade<TCard>
    {
        private readonly IGameFieldFactory<TCard, TurnBasedGameState> _gameFactory;

        private GameField<TCard, TurnBasedGameState> _gameField;

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

        public TurnBasedGameFieldFacade(IGameFieldFactory<TCard, TurnBasedGameState> gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void NewGame()
        {
            _gameField = _gameFactory.Create();
        }

        public ICollection<TCard> GetRemainingCards()
        {
            throw new NotImplementedException();
        }

        public void PickCard(TCard card)
        {
            throw new NotImplementedException();
        }

        public int GetRemainingTurns()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<CardRevelationEventArgs<TCard>> OnCardRevealed;

        public event EventHandler<CardMatchEventArgs<TCard>> OnCardMatched;

        public event EventHandler<CardBonusEventArgs> OnBonusApplied;
    }
}
