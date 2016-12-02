using CardMatch.Core.GameFields.Factory.Cards;
using CardMatch.Core.Models.Cards;
using System.Collections.Generic;

namespace CardMatch.Core.GameFields.Core
{
    public abstract class GameFieldFactory : IGameFieldFactory
    {
        private readonly ICardFactory _cardFactory;

        protected abstract int ColumnCount { get; }
        protected abstract int RowCount { get; }

        protected virtual int TurnCount
        {
            get
            {
                return 20;
            }
        }

        public GameFieldFactory(ICardFactory cardFactory)
        {
            _cardFactory = cardFactory;
        }

        public GameField Create(int rowCount, int columnCount)
        {
            var cardCount = rowCount * columnCount;
            var content = new List<ICard>();

            var cards = _cardFactory.Create(cardCount);

            content.AddRange(cards);

            var gameField = new GameField()
            {
                TurnsLeft = TurnCount,
            };
            gameField.SetCards(content.ToArray());

            return gameField;
        }

        public GameField Create()
        {
            return Create(RowCount, ColumnCount);
        }
    }
}
