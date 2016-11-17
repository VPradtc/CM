using CardMatch.Core.GameFields.CardPositions;
using CardMatch.Core.Models;
using CardMatch.Core.Models.Cards;
using System;
using System.Linq;

namespace CardMatch.Core.GameFields
{
    public class GameField<TCard, TContext>
        where TCard: IPairedCard
    {
        public ActiveCard<TCard>[] Cards { get; private set; }

        public TContext Context { get; set; }

        public void SetCards(TCard[] cards)
        {
            Cards = cards.Select(card => CreateActiveCard(card)).ToArray();
        }

        private ActiveCard<TCard> CreateActiveCard(TCard card)
        {
            return new ActiveCard<TCard>(card);
        }

        public ActiveCard<TCard>[] GetRemainingCards()
        {
            return Cards;
        }

        public ActiveCard<TCard> PickCard(ActiveCard<TCard> target)
        {
            if (!Cards.Contains(target))
            {
                throw new InvalidOperationException();
            }

            target.State.Trigger();

            return target;
        }
    }
}
