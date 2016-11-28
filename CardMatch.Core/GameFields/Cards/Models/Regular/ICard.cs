using CardMatch.Core.GameFields;
using CardMatch.Core.Models.Enums;

namespace CardMatch.Core.Models.Cards
{
    public interface ICard
    {
        CardStatus Status { get; set; }

        string Value { get; }

        bool IsPairTo(ICard other);

        void Execute(GameField context);

        ICard Clone();
    }
}
