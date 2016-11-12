using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch.Core.Models
{
    public class GameField
    {
        private Card[,] _field;

        public GameField(Card[,] field)
        {
            _field = field;
        }
    }
}
