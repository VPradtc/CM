using System;
using CardMatch.Core.Models.Cards;
using CardMatch.Core.GameFields.Globals;
using System.Linq;
using System.Collections.Generic;
using CardMatch.Core.Utils;

namespace CardMatch.Core.GameFields.Factory.Cards
{
    public class CardFactory : ICardFactory
    {
        private readonly ICardSelector _cardSelector;

        public CardFactory(ICardSelector cardSelector)
        {
            _cardSelector = cardSelector;
        }

        public ICard[] Create(int cardCount)
        {
            if(cardCount % 2 != 0)
            {
                throw new ArgumentException("cardCount must be an even value");
            }

            var pairCount = cardCount / 2;

            var pairs = Enumerable.Range(0, pairCount).Select(index => CreatePair());

            var cards = pairs.SelectMany(pair => new List<ICard> { pair.Item1, pair.Item2 }).ToList().Shuffle().ToArray();

            return cards;
        }

        private Tuple<ICard, ICard> CreatePair()
        {
            var card = _cardSelector.GetNext();

            return new Tuple<ICard, ICard>(card, card.Clone());
        }
    }
}
