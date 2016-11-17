using CardMatch.Core.Models.Cards;
using CardMatch.TurnBased.GameFields;

namespace CardMatch.TurnBased.Cards.Bonus
{
    public class ExtraTurnsBonusCard : BonusCard
    {
        public override string Name
        {
            get
            {
                return "Extra Turns";
            }
        }

        public int TurnCount { get; set; }
    }
}
