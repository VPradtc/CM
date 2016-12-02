using CardMatch.Console;
using CardMatch.Core.Models.Enums;
using CardMatch.TurnBased.Facade;
using Ninject;
using System;
using System.Linq;

namespace CardMatch.ConsoleApp
{
    class Program
    {
        private static IKernel kernel = new StandardKernel(new MainModule());

        private static ITurnBasedGameFieldFacade _gameFacade;

        private static GameViewmodel _viewmodel = new GameViewmodel();

        static void Main(string[] args)
        {
            Init();
            RunTest();
        }

        private static void RunTest()
        {
            _gameFacade.NewGame();

            while (!_gameFacade.IsOver())
            {
                PollGameState();
                DisplayGameState();
                RequestUserAction();
            }
        }

        private static void RequestUserAction()
        {
            int cardIndex;
            string input = System.Console.ReadLine();
            if (!int.TryParse(input, out cardIndex))
            {
                System.Console.WriteLine("Invalid card index. Try again:");
                RequestUserAction();
            }

            var targetCard = _viewmodel.Cards[cardIndex];

            _gameFacade.PickCard(targetCard);
        }

        private static void DisplayGameState()
        {
            System.Console.WriteLine("Turns left: {0}",_viewmodel.TurnsLeft);

            foreach (var card in _viewmodel.Cards)
            {
                var cardChar = card.Status == CardStatus.Revealed ? card.Value : "#";

                System.Console.Write(cardChar);
            }

            System.Console.WriteLine();
        }

        private static void PollGameState()
        {
            _viewmodel.TurnsLeft = _gameFacade.GetRemainingTurns();
            _viewmodel.Cards = _gameFacade.GetRemainingCards().ToList();
        }

        private static void Init()
        {
            _gameFacade = (ITurnBasedGameFieldFacade)kernel.Get<ITurnBasedGameFieldFacade>();
        }
    }
}
