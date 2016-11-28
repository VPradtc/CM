using CardMatch.Core.GameFields.Core;
using CardMatch.Core.GameFields.Factory.Cards;

namespace CardMatch.Core.GameFields
{
    public class LargeGameFieldFactory : GameFieldFactory
    {
        protected override int ColumnCount
        {
            get { return 10; }
        }

        protected override int RowCount
        {
            get { return 8; }
        }

        public LargeGameFieldFactory(ICardFactory cardFactory)
            : base(cardFactory)
        {
        }
    }
}