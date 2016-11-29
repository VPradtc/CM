using CardMatch.Core.GameFields;
using CardMatch.Core.GameFields.Core;
using CardMatch.Core.GameFields.Factory.Cards;
using CardMatch.Core.GameFields.Globals;
using Ninject.Modules;

namespace CardMatch.ConsoleApp
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IGameFieldFactory>().To<SmallGameFieldFactory>();
            Kernel.Bind<ICardFactory>().To<CardFactory>();
            Kernel.Bind<ICardContainer>().To<CardContainer>();
        }
    }
}
