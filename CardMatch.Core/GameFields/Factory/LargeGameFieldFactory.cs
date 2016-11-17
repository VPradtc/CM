using CardMatch.Core.GameFields.Core;
using CardMatch.Core.GameFields.Factory.Cards;
using CardMatch.Core.Models.Cards;

namespace CardMatch.Core.GameFields
{
    public class LargeGameFieldFactory<TCard, TContext> : GameFieldFactory<TCard, TContext>
        where TCard : IPairedCard
    {
        protected override int ColumnCount
        {
            get { return 10; }
        }

        protected override int RowCount
        {
            get { return 8; }
        }

        public LargeGameFieldFactory(ICardFactory<TCard> cardFactory)
            : base(cardFactory)
        {
        }
    }
}