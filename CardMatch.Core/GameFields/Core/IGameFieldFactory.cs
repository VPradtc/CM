using CardMatch.Core.Models;

namespace CardMatch.Core.GameFields.Core
{
    public interface IGameFieldFactory
    {
        GameField Create();
    }
}
