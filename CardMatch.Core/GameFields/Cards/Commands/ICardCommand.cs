using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch.Core.GameFields.Cards.Commands
{
    public interface ICardCommand<TCard, TContext>
    {
        void Execute(TCard card, TContext context);
    }
}
