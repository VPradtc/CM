using CardMatch.Core.GameFields.Core;
using CardMatch.Core.GameFields.Factory.Cards;

namespace CardMatch.Core.GameFields
{
    public class SmallGameFieldFactory : GameFieldFactory
    {
        protected override int ColumnCount
        {
            get { return 4; }
        }

        protected override int RowCount
        {
            get { return 3; }
        }

        public SmallGameFieldFactory(ICardFactory cardFactory)
            : base(cardFactory)
        {
        }
    }
}