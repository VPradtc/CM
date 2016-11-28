using CardMatch.Core.Models.Cards;

namespace CardMatch.Core.GameFields.Globals
{
    public interface ICardContainer
    {
        ICard GetCard(string identifier);

        string[] GetSupportedIdentifiers();
    }
}
