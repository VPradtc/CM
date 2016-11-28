using CardMatch.Core.GameFields;
using CardMatch.Core.Models.Cards;

namespace CardMatch.TurnBased.Cards.Bonus
{
    public class ExtraTurnsBonusCard : BonusCard
    {
        public override string Value
        {
            get
            {
                return "Extra Turns";
            }
        }

        public int TurnCount { get; set; }

        public override void Execute(GameField context)
        {
            context.TurnsLeft += TurnCount;
        }
    }
}
