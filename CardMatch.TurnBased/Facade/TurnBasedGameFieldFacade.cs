using System;
using System.Collections.Generic;
using CardMatch.Core.Models.Cards;
using CardMatch.Core.GameFields;
using CardMatch.Core.GameFields.Core;
using CardMatch.Core.Utils;

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
            if (_gameField != null)
            {
                _gameField.GameFieldChanged -= _gameField_GameFieldChanged;
            }

            _gameField = _gameFieldFactory.Create();
            _gameField.GameFieldChanged += _gameField_GameFieldChanged;
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
            var isVictory = IsVictory();

            var isDefeat = IsDefeat();

            return isVictory || isDefeat;
        }

        public bool IsDefeat()
        {
            var isDefeat = _gameField.TurnsLeft <= 0 && _gameField.ActiveCards.Length > 0;
            return isDefeat;
        }

        public bool IsVictory()
        {
            var isVictory = _gameField.TurnsLeft >= 0 && _gameField.ActiveCards.Length == 0;
            return isVictory;
        }

        public void PickCard(ICard card)
        {
            _gameField.PickCard(card);
        }

        public event EventHandler GameFieldChanged;

        private void _gameField_GameFieldChanged(object sender, EventArgs e)
        {
            GameFieldChanged.SafeInvoke(sender, e);
        }
    }
}
