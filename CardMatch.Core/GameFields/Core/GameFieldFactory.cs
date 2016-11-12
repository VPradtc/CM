using CardMatch.Core.Models;
using System;
using System.Collections.Generic;

namespace CardMatch.Core.GameFields.Core
{
    public abstract class GameFieldFactory : IGameFieldFactory
    {
        protected abstract int ColumnCount { get; }
        protected abstract int RowCount { get; }

        protected virtual Card CreateCard(int rowIndex, int columnIndex)
        {
            return new Card();
        }

        public GameField Create(int rowCount, int columnCount)
        {
            var content = new Card[rowCount, columnCount];

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    content[rowIndex, columnIndex] = CreateCard(rowIndex, columnIndex);
                }
            }

            var gameField = GameField.Instance;
            gameField.SetField(content);

            return gameField;
        }

        public GameField Create()
        {
            return Create(RowCount, ColumnCount);
        }
    }
}
