using CardMatch.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch.Core.GameFields.CardPositions.States
{
    public abstract class ClosedActiveCardState<TCard> : ActiveCardState<TCard>
    {
        public ClosedActiveCardState(ActiveCard<TCard> owner)
            : base(owner)
        {
        }

        public override CardStatus Status
        {
            get { return CardStatus.Closed; }
        }

        public override void Trigger()
        {
        }
    }
}
