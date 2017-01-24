using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pairs.Client.Statuses
{
    public class MatchedCardViewmodelStatus : ICardViewmodelStatus
    {
        public MatchedCardViewmodelStatus()
        {
        }

        public void Flip()
        {
            throw new NotSupportedException();
        }

        public CardStatus Status
        {
            get
            {
                return CardStatus.Matched;
            }
        }

        public Brush ActiveImage
        {
            get
            {
                return new SolidColorBrush(Colors.Transparent);
            }
        }
    }
}
