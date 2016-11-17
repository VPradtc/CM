using CardMatch.Core.Models.Cards;
using CardMatch.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch.Core.GameFields.CardPositions.States
{
    public class RemovedActiveCardState<TCard> : ActiveCardState<TCard>
        where TCard : IPairedCard
    {
        public RemovedActiveCardState(ActiveCard<TCard> owner)
            : base(owner)
        {
        }

        public override CardStatus Status
        {
            get { return CardStatus.Removed; }
        }

        public override void Trigger()
        {
            throw new InvalidOperationException();
        }
    }
}
