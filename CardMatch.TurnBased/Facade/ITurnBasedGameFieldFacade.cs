using CardMatch.Core.GameFields.CardPositions;
using CardMatch.Core.Models;
using System;
using System.Collections.Generic;

namespace CardMatch.TurnBased.Facade
{
    public interface ITurnBasedGameFieldFacade<TCard>
    {
        void NewGame();

        ICollection<ActiveCard<TCard>> GetRemainingCards();
        void PickCard(TCard card);

        int GetRemainingTurns();

        event EventHandler<CardRevelationEventArgs<TCard>> OnCardRevealed;
        event EventHandler<CardMatchEventArgs<TCard>> OnCardMatched;
        event EventHandler<CardBonusEventArgs> OnBonusApplied;
    }
}
