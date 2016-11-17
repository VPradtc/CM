using CardMatch.Core.GameFields.Factory.Cards;
using CardMatch.Core.Models;
using CardMatch.Core.Models.Cards;
using System;
using System.Collections.Generic;

namespace CardMatch.Core.GameFields.Core
{
    public abstract class GameFieldFactory<TCard, TContext> : IGameFieldFactory<TCard, TContext>
        where TCard : IPairedCard
    {
        private readonly ICardFactory<TCard> _cardFactory;

        protected abstract int ColumnCount { get; }
        protected abstract int RowCount { get; }

        public GameFieldFactory(ICardFactory<TCard> cardFactory)
        {
            _cardFactory = cardFactory;
        }

        protected virtual TCard CreateCard(int rowIndex, int columnIndex)
        {
            return _cardFactory.Create();
        }

        public GameField<TCard, TContext> Create(int rowCount, int columnCount)
        {
            var cardCount = rowCount * columnCount;
            var content = new List<TCard>();

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    content.Add(CreateCard(rowIndex, columnIndex));
                }
            }

            var gameField = new GameField<TCard, TContext>();
            gameField.SetCards(content.ToArray());

            return gameField;
        }

        public GameField<TCard, TContext> Create()
        {
            return Create(RowCount, ColumnCount);
        }
    }
}
