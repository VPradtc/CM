using CardMatch.Core.GameFields.Core;

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
    }
}