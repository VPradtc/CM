using System;
using System.Collections.Generic;
using CardMatch.Core.Models.Cards;
using CardMatch.Core.GameFields;
using CardMatch.Core.GameFields.Core;

namespace CardMatch.TurnBased.Facade
{
    public class TurnBasedGameFieldFacade : ITurnBasedGameFieldFacade
    {
        private readonly IGameFieldFactory _gameFieldFactory;
        private GameField _gameField;

        public TurnBasedGameFieldFacade(IGameFieldFactory gameFieldFactory)
        {
            _gameFieldFactory = gameFieldFactory;
        }

        public void NewGame()
        {
            _gameField = _gameFieldFactory.Create();
        }

        public ICollection<ICard> GetRemainingCards()
        {
            return _gameField.ActiveCards;
        }

        public int GetRemainingTurns()
        {
            return _gameField.TurnsLeft;
        }

        public bool IsOver()
        {
            var isVictory = _gameField.TurnsLeft >= 0 && _gameField.ActiveCards.Length == 0;

            var isDefeat = _gameField.TurnsLeft <= 0 && _gameField.ActiveCards.Length > 0;

            return isVictory || isDefeat;
        }

        public void PickCard(ICard card)
        {
            _gameField.PickCard(card);
        }
    }
}
