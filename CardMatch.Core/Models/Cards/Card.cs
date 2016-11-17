using CardMatch.Core.Models.Enums;

namespace CardMatch.Core.Models
{
    public abstract class Card
    {
        public CardStatus Status { get; set; }
    }
}
