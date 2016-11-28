using System;
using CardMatch.Core.GameFields;
using CardMatch.Core.Models.Cards;
using System.Linq;

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
            foreach (var removal in Enumerable.Repeat(0, PairCount))
            {
                RemovePair(context);
            }
        }

        private void RemovePair(GameField context)
        {
            var pair = context.GetPairs().FirstOrDefault();

            if (pair == null)
            {
                return;
            }

            context.CreateMatch(pair);
        }
    }
}
