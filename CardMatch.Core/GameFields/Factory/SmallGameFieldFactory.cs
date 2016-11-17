using CardMatch.Core.GameFields.Core;
using CardMatch.Core.GameFields.Factory.Cards;
using CardMatch.Core.Models.Cards;

namespace CardMatch.Core.GameFields
{
    public class SmallGameFieldFactory<TCard, TContext> : GameFieldFactory<TCard, TContext>
        where TCard : ICard
    {
        protected override int ColumnCount
        {
            get { return 4; }
        }

        protected override int RowCount
        {
            get { return 3; }
        }

        public SmallGameFieldFactory(ICardFactory<TCard> cardFactory)
            : base(cardFactory)
        {
        }
    }
}