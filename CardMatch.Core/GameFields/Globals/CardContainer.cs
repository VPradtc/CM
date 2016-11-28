using System;
using CardMatch.Core.Models.Cards;
using System.Collections.Generic;
using CardMatch.Core.GameFields.Globals.Bindings;
using CardMatch.Core.Models.Cards.Regular;
using System.Linq;
using CardMatch.Core.Cards.Bonus;

namespace CardMatch.Core.GameFields.Globals
{
    //singleton
    public class CardContainer : ICardContainer
    {
        private readonly IEnumerable<CardBinding> _bindings;

        public CardContainer()
        {
            var regularBindings = CreateRegularBindings();
            var bonusBindings = CreateBonusBindings();

            _bindings = regularBindings.Concat(bonusBindings);
        }

        private IEnumerable<CardBinding> CreateRegularBindings()
        {
            var regularCards = new List<string>
            {
                "Star",
                "Fish",
                "Ball",
                "Ace",
            };

            return regularCards.Select(cardId => CreateBinding(cardId));
        }

        private IEnumerable<CardBinding> CreateBonusBindings()
        {
            return new List<CardBinding>
            {
                new CardBinding() { Identifier = "ExtraTurns", Card = new ExtraTurnsBonusCard() },
                new CardBinding() { Identifier = "RemovePairs", Card = new RemovePairsBonusCard() },
            };
        }

        private CardBinding CreateBinding(string identifier)
        {
            var binding = new CardBinding()
            {
                Identifier = identifier,
                Card = new RegularCard()
                {
                    Value = identifier,
                },
            };

            return binding;
        }

        public ICard GetCard(string identifier)
        {
            var target = _bindings.FirstOrDefault(b => b.Identifier == identifier);

            if (target == null)
            {
                throw new ArgumentException(String.Format("Identifier {0} is not registered.", identifier));
            }

            var card = target.Card.Clone();

            return card;
        }

        public string[] GetSupportedIdentifiers()
        {
            return _bindings.Select(b => b.Identifier).ToArray();
        }
    }
}
