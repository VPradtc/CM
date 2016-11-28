using CardMatch.Core.Models.Cards;

namespace CardMatch.Core.GameFields.Factory.Cards
{
    public interface ICardFactory
    {
        ICard Create();
    }
}
