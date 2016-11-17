using CardMatch.Core.GameFields.CardPositions;
using CardMatch.Core.Models;
using System.Linq;

namespace CardMatch.Core.GameFields
{
    public class GameField<TCard, TContext>
    {
        private ActiveCard<TCard>[] _cards;

        public TContext Context { get; set; }

        public void SetCards(TCard[] cards)
        {
            _cards = cards.Select(card => CreateActiveCard(card)).ToArray();
        }

        private ActiveCard<TCard> CreateActiveCard(TCard card)
        {
            return new ActiveCard<TCard>(card);
        }

        public ActiveCard<TCard>[] GetRemainingCards()
        {
            return _cards;
        }
    }
}
