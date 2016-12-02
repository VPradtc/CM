using CardMatch.Core.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch.Console
{
    public class GameViewmodel
    {
        public int TurnsLeft { get; set; }
        public IList<ICard> Cards { get; set; }
    }
}
