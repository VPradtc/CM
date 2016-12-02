using CardMatch.Core.Models.Cards;
using CardMatch.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardMatch.Core.GameFields
{
    public class GameField
    {
        public int TurnsLeft { get; set; }

        public ICard[] Cards { get; private set; }

        public ICard[] ActiveCards
        {
            get
            {
                return Cards.Where(card => card.Status != CardStatus.Removed).ToArray();
            }
        }

        public void SetCards(ICard[] cards)
        {
            Cards = cards;
        }

        public void PickCard(ICard target)
        {
            if (!Cards.Contains(target))
            {
                throw new InvalidOperationException();
            }

            target.Execute(this);

            TurnsLeft--;
        }

        public Tuple<ICard, ICard>[] GetPairs()
        {
            var cards = ActiveCards;

            var pairs = new List<Tuple<ICard, ICard>>();

            foreach (var card in cards)
            {
                if (pairs.Any(pair => pair.Item1 == card || card == pair.Item2))
                {
                    continue;
                }

                var pairedCard = cards.FirstOrDefault(pairCard => pairCard != card && card.IsPairTo(pairCard));
                if (pairedCard == null)
                {
                    continue;
                }

                var newPair = new Tuple<ICard, ICard>(card, pairedCard);
                pairs.Add(newPair);
            }

            return pairs.ToArray();
        }

        public ICard[] GetRevealedCards()
        {
            var activeCards = ActiveCards;
            var revealedCards = activeCards.Where(card => card.Status == CardStatus.Revealed);

            return revealedCards.ToArray();
        }

        public void CloseRevealedCards()
        {
            var cards = GetRevealedCards();

            foreach (var card in cards)
            {
                card.Status = CardStatus.Closed;
            }
        }

        public void CreateMatch(Tuple<ICard, ICard> pairedCards)
        {
            foreach (var card in new[] { pairedCards.Item1, pairedCards.Item2 })
            {
                if (!Cards.Contains(card))
                {
                    throw new InvalidOperationException();
                }

                card.Status = CardStatus.Removed;
            }
        }
    }
}
