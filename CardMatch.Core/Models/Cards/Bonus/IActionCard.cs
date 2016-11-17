
namespace CardMatch.Core.Models.Cards.Bonus
{
    public interface IActionCard<TTarget>
    {
        void Apply(TTarget target);
    }
}
