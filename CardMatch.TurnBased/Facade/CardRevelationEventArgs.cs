using CardMatch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardMatch.TurnBased.Facade
{
    public class CardRevelationEventArgs<TCard> : EventArgs
    {
        public TCard Card { get; set; }
    }
}
