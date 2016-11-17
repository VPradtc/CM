using CardMatch.Core.Models.Enums;

namespace CardMatch.Core.GameFields.CardPositions
{
    public interface IActiveCardState
    {
        CardStatus Status { get; }

        void Trigger();
    }
}
