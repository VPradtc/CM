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

        public void SetCards(ICard[] cards)
        {
            Cards = cards;
        }

        public ICard[] GetRemainingCards()
        {
            return Cards;
        }

        public void PickCard(ICard target)
        {
            if (!Cards.Contains(target))
            {
                throw new InvalidOperationException();
            }
        }

        public ICard[] GetActiveCards()
        {
            return Cards.Where(card => card.Status != CardStatus.Removed).ToArray();
        }

        public ICard[] GetRevealedCards()
        {
            var activeCards = GetActiveCards();
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

        public void CreateMatch(List<ICard> pairedCards)
        {
            foreach (var card in pairedCards)
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
