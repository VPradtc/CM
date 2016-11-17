using CardMatch.Core.Models.Cards;
using CardMatch.Core.Models.Enums;

namespace CardMatch.Core.Models
{
    public abstract class Card : IPairedCard
    {
        public CardStatus Status { get; set; }

        public abstract string Value { get; set; }

        public abstract bool IsPairTo(IPairedCard other);
    }
}
