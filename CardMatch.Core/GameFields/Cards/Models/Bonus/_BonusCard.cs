namespace CardMatch.Core.Models.Cards
{
    public abstract class BonusCard : Card
    {
        public override string Value
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

        public override bool IsPairTo(IPairedCard other)
        {
            return false;
        }
    }
}
