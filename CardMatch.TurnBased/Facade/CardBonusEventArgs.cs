using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardMatch.TurnBased.Facade
{
    public class CardBonusEventArgs : EventArgs
    {
        public string BonusName { get; set; }

        public ICollection<KeyValuePair<string, string>> Properties { get; set; }
    }
}
