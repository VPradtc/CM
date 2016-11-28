using System;
using CardMatch.Core.GameFields;
using CardMatch.Core.Models.Cards;

namespace CardMatch.TurnBased.Cards.Bonus
{
    public class RemovePairsBonusCard : BonusCard
    {
        public int PairCount { get; set; }

        public override string Value
        {
            get
            {
                return "Remove Pairs of Cards";
            }
        }

        public override void Execute(GameField context)
        {
            throw new NotImplementedException();
        }
    }
}
