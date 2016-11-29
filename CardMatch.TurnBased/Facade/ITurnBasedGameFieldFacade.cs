using CardMatch.Core.Models.Cards;
using System;
using System.Collections.Generic;

namespace CardMatch.TurnBased.Facade
{
    public interface ITurnBasedGameFieldFacade
    {
        void NewGame();

        ICollection<ICard> GetRemainingCards();
        void PickCard(ICard card);

        int GetRemainingTurns();

        bool IsOver();
    }
}
