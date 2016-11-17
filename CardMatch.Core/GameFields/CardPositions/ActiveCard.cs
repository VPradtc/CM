using CardMatch.Core.Models.Cards;
using CardMatch.Core.Models.Enums;

namespace CardMatch.Core.GameFields.CardPositions
{
    public class ActiveCard<TCard>
        where TCard : ICard
    {
        public readonly TCard Card;

        public IActiveCardState State { get; set; }

        public CardStatus Status { get { return State.Status; } }

        public ActiveCard(TCard card)
        {
            Card = card;
        }
    }
}
