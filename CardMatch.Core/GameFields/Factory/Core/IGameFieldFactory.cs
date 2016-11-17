using CardMatch.Core.Models;

namespace CardMatch.Core.GameFields.Core
{
    public interface IGameFieldFactory<TCard>
    {
        GameField<TCard> Create();
    }
}
