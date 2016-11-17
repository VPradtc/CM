﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch.Core.GameFields.Factory.Cards
{
    public interface ICardFactory<TCard>
    {
        TCard Create();
    }
}