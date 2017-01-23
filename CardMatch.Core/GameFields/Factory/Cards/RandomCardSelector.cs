using CardMatch.Core.GameFields.Globals;
using CardMatch.Core.Models.Cards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CardMatch.Core.GameFields.Factory.Cards
{
    public class RandomCardSelector : IEnumerator<ICard>, ICardSelector
    {
        private readonly ICardContainer _container;

        private string _currentIdentifier;
        private Random _indexGenerator;

        public RandomCardSelector(ICardContainer container)
        {
            _container = container;
            _indexGenerator = new Random();

            Reset();
        }

        public ICard Current
        {
            get { return _container.GetCard(_currentIdentifier); }
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return _container.GetCard(_currentIdentifier); }
        }

        public bool MoveNext()
        {
            var identifiers = _container.GetSupportedIdentifiers().ToList();
            var nextIndex = _indexGenerator.Next(identifiers.Count());

            _currentIdentifier = identifiers[nextIndex];

            return true;
        }

        public void Reset()
        {
            _currentIdentifier = _container.GetSupportedIdentifiers().FirstOrDefault();
        }

        public ICard GetNext()
        {
            MoveNext();
            return Current;
        }
    }
}
