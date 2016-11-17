namespace CardMatch.Core.Models.Cards
{
    public abstract class BonusCard : IPairedCard
    {
        public string Value
        {
            get
            {
                return Name;
            }
            set
            {
            }
        }

        public abstract string Name { get; }

        public bool IsPairTo(IPairedCard other)
        {
            return false;
        }
    }
}
