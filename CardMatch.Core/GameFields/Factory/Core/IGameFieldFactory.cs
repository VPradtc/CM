using CardMatch.Core.Models;
using CardMatch.Core.Models.Cards;

namespace CardMatch.Core.GameFields.Core
{
    public interface IGameFieldFactory<TCard, TContext>
        where TCard : ICard
    {
        GameField<TCard, TContext> Create();
    }
}
