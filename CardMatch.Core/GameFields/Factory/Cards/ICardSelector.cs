using CardMatch.Core.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardMatch.Core.GameFields.Factory.Cards
{
    public interface ICardSelector
    {
        ICard GetNext();
    }
}
