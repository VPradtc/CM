using CardMatch.Core.Models.Cards;
using CardMatch.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch.Core.GameFields.CardPositions.States
{
    public abstract class ActiveCardState<TCard> : IActiveCardState
        where TCard : ICard
    {
        protected readonly ActiveCard<TCard> _owner;

        public ActiveCardState(ActiveCard<TCard> owner)
        {
            _owner = owner;
        }

        public abstract CardStatus Status { get; }

        public abstract void Trigger();
    }
}
