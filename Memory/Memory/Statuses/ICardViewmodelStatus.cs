using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Pairs.Client.Statuses
{
    public interface ICardViewmodelStatus
    {
        Brush ActiveImage { get; }

        CardStatus Status { get; }

        void Flip();
    }
}
