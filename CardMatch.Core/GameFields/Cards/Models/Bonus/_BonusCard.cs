namespace CardMatch.Core.Models.Cards
{
    public abstract class BonusCard : ICard
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

        public bool IsPairTo(ICard other)
        {
            return false;
        }
    }
}
