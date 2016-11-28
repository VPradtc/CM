using CardMatch.TurnBased.Facade;
using Ninject;

namespace CardMatch.ConsoleApp
{
    class Program
    {
        private static IKernel kernel = new StandardKernel(new MainModule());

        private static ITurnBasedGameFieldFacade _gameFacade;

        static void Main(string[] args)
        {
            Init();
            RunTest();
        }

        private static void RunTest()
        {
            _gameFacade.NewGame();
        }

        private static void Init()
        {
            _gameFacade = (ITurnBasedGameFieldFacade)kernel.Get<ITurnBasedGameFieldFacade>();
        }
    }
}
