using CardMatch.Core.GameFields;
using CardMatch.Core.GameFields.Core;
using CardMatch.Core.GameFields.Snapshot;
using CardMatch.Core.Models.Cards;
using CardMatch.Core.Utils;
using CardMatch.Serialization.Core;
using System;
using System.Collections.Generic;

namespace CardMatch.TurnBased.Facade
{
    public class TurnBasedGameFieldFacade : ITurnBasedGameFieldFacade
    {
        private readonly string _savedGamePath = "game.xml";

        private readonly IGameFieldFactory _gameFieldFactory;
        private readonly ISerializer<GameFieldSnapshot> _serializer;

        private GameField _gameField;

        public TurnBasedGameFieldFacade(IGameFieldFactory gameFieldFactory, ISerializer<GameFieldSnapshot> serializer)
        {
            _gameFieldFactory = gameFieldFactory;
            _serializer = serializer;
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

        public void Save()
        {
            var snapshot = _gameField.CreateSnapshot();

            _serializer.Serialize(snapshot, _savedGamePath);
        }
    }
}
