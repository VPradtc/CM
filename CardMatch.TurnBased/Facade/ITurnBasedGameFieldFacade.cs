using CardMatch.Core.GameFields.CardPositions;
using CardMatch.Core.Models;
using CardMatch.Core.Models.Cards;
using System;
using System.Collections.Generic;

namespace CardMatch.TurnBased.Facade
{
    public interface ITurnBasedGameFieldFacade<TCard>
        where TCard : ICard
    {
        void NewGame();

        ICollection<ActiveCard<TCard>> GetRemainingCards();
        void PickCard(ActiveCard<TCard> card);

        int GetRemainingTurns();

        event EventHandler<EventArgs> CardsClosing;
        event EventHandler<CardRevelationEventArgs<TCard>> OnCardRevealed;
        event EventHandler<CardMatchEventArgs<TCard>> OnCardMatched;
        event EventHandler<CardBonusEventArgs> OnBonusApplied;
    }
}
