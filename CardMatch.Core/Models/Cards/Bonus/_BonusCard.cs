using CardMatch.Core.Models.Cards.Bonus;

namespace CardMatch.Core.Models.Cards
{
    public abstract class BonusCard<TTarget> : Card, IActionCard<TTarget>
    {
        public string Name { get; set; }

        public abstract void Apply(TTarget target);
    }
}
