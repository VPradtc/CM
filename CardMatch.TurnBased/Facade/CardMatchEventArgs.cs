using CardMatch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardMatch.TurnBased.Facade
{
    public class CardMatchEventArgs<TCard> : EventArgs
    {
        public Tuple<TCard, TCard> CardPair { get; set; }
    }
}
