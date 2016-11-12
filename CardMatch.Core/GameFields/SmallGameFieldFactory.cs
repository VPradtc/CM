using CardMatch.Core.GameFields.Core;

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
    }
}