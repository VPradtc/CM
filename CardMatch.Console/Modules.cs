using CardMatch.Core.GameFields;
using CardMatch.Core.GameFields.Core;
using CardMatch.Core.GameFields.Factory.Cards;
using CardMatch.Core.GameFields.Globals;
using CardMatch.Serialization.Core;
using CardMatch.Serialization.XML;
using CardMatch.TurnBased.Facade;
using Ninject.Modules;

namespace CardMatch.ConsoleApp
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IGameFieldFactory>().To<SmallGameFieldFactory>();
            Kernel.Bind<ICardFactory>().To<CardFactory>();
            Kernel.Bind<ICardContainer>().ToMethod(ctx => CardContainer.Instance);
            Kernel.Bind<GameField>().ToSelf();
            Kernel.Bind<ITurnBasedGameFieldFacade>().To<TurnBasedGameFieldFacade>();

            Kernel.Bind<ICardSelector>().To<RandomCardSelector>();

            Kernel.Bind(typeof(ISerializer<>)).To(typeof(XmlSnapshotSerializer<>));
        }
    }
}
