using CardMatch.Core.Models.Cards;
using CardMatch.TurnBased.GameFields;

namespace CardMatch.TurnBased.Cards.Bonus
{
    public class RemovePairsBonusCard : BonusCard
    {
        public override string Name
        {
            get
            {
                return "Remove Pairs of Cards";
            }
        }

        public int PairCount { get; set; }
    }
}
