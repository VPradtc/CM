using System;
using CardMatch.Core.Models.Cards;
using CardMatch.Core.GameFields.Globals;
using System.Linq;
using System.Collections.Generic;

namespace CardMatch.Core.GameFields.Factory.Cards
{
    public class CardFactory : ICardFactory
    {
        private readonly ICardContainer _container;

        public CardFactory(ICardContainer container)
        {
            _container = container;
        }

        public ICard[] Create(int cardCount)
        {
            if(cardCount % 2 != 0)
            {
                throw new ArgumentException("cardCount must be an even value");
            }

            var pairCount = cardCount / 2;

            var identifiers = _container.GetSupportedIdentifiers();

            var pairs = Enumerable.Range(0, pairCount).Select(index => CreatePair(index, identifiers));

            var cards = pairs.SelectMany(pair => new List<ICard> { pair.Item1, pair.Item2 }).ToArray();

            return cards;
        }

        private Tuple<ICard, ICard> CreatePair(int index, string[] identifiers)
        {
            var identifierIndex = index % identifiers.Length;
            var identifier = identifiers[identifierIndex];

            var card = _container.GetCard(identifier);

            return new Tuple<ICard, ICard>(card, card.Clone());
        }
    }
}
