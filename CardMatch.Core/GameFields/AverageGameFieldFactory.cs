using CardMatch.Core.GameFields.Core;

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
    }
}
