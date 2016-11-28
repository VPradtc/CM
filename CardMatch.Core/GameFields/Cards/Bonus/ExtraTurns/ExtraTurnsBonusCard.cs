using CardMatch.Core.GameFields;
using CardMatch.Core.Models.Cards;

namespace CardMatch.Core.Cards.Bonus
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

        protected override ICard CloneOwnProperties()
        {
            return new ExtraTurnsBonusCard()
            {
                TurnCount = TurnCount,
            };
        }
    }
}
