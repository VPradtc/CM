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

        public GameFieldFactory(ICardFactory cardFactory)
        {
            _cardFactory = cardFactory;
        }

        protected virtual ICard CreateCard(int rowIndex, int columnIndex)
        {
            return _cardFactory.Create();
        }

        public GameField Create(int rowCount, int columnCount)
        {
            var cardCount = rowCount * columnCount;
            var content = new List<ICard>();

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    content.Add(CreateCard(rowIndex, columnIndex));
                }
            }

            var gameField = new GameField();
            gameField.SetCards(content.ToArray());

            return gameField;
        }

        public GameField Create()
        {
            return Create(RowCount, ColumnCount);
        }
    }
}
