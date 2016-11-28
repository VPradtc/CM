using CardMatch.Core.GameFields.Core;
using CardMatch.Core.GameFields.Factory.Cards;

namespace CardMatch.Core.GameFields
{
    public class AverageGameFieldFactory : GameFieldFactory
    {
        protected override int ColumnCount
        {
            get { return 7; }
        }

        protected override int RowCount
        {
            get { return 5; }
        }

        public AverageGameFieldFactory(ICardFactory cardFactory)
            : base(cardFactory)
        {
        }
    }
}
